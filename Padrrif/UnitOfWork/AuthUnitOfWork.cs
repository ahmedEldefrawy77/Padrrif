using Microsoft.AspNetCore.Http.HttpResults;
using Padrrif.Dto;
using Padrrif.Entities;
using Padrrif.UnitOfWork.Interface;

namespace Padrrif;
public class AuthUnitOfWork : IAuthUnitOfWork
{
    private readonly IRepository<User> _repository;
    private readonly IWebHostEnvironment _env;
    private readonly IHttpContextAccessor _contextAccessor;
    private readonly IJwtProvider _jwtProvider;
    private readonly JwtAccessOptions _jwtAccessOptions;
    private readonly IHubContext<NotificationHub, INotificationClient> _hubContext;
    private readonly NotificationHubConecctedUsers _conecctedUsers;
    private readonly IRepository<Notifaction> _notifactionRepository;
    private readonly IUserPrivilegeUnitOfWork _userPrivilegeUnitOfWork;

    public AuthUnitOfWork(IRepository<User> repository, IWebHostEnvironment env,
        IHttpContextAccessor contextAccessor, IJwtProvider jwtProvider, IOptions<JwtAccessOptions> jwtAccessOption,
        IHubContext<NotificationHub, INotificationClient> hubContext, NotificationHubConecctedUsers conecctedUsers, IRepository<Notifaction> notifactionRepository,
        IUserPrivilegeUnitOfWork userPrivilegeUnitOfWork)
    {
        _repository = repository;
        _env = env;
        _contextAccessor = contextAccessor;
        _jwtProvider = jwtProvider;
        _jwtAccessOptions = jwtAccessOption.Value;
        _hubContext = hubContext;
        _conecctedUsers = conecctedUsers;
        _notifactionRepository = notifactionRepository;
        _userPrivilegeUnitOfWork  = userPrivilegeUnitOfWork;
    }

    public async Task RegisterAsFarmer(User user) => await Register(user, RoleEnum.Farmer);
    public async Task<TokenDto> RegisterAsEmpolyee(User user) => await Register(user, RoleEnum.Empolyee);
    #region login
    public async Task<UserLoginDto?> Login(LoginDto dto)
    {
        User? userFromDb = await _repository.GetSingleEntityWithSomeCondiition(e=> e.Where(u=>u.Email == dto.Email || u.IdentityNumber == dto.IdentityNumber));

        if (dto.IdentityNumber > 99999999)
            userFromDb = await _repository.GetSingleEntityWithSomeCondiition(q => q.Where(u => u.IdentityNumber == dto.IdentityNumber && u.IsConfirmed));

        if (!dto.Email.IsNullOrEmpty())
            userFromDb = await _repository.GetSingleEntityWithSomeCondiition(q => q.Where(u => u.Email == dto.Email && u.IsConfirmed));

        if (userFromDb == null)
            return null;

        if (!BCrypt.Net.BCrypt.Verify(dto.Password, userFromDb.Password))
            return null;
      
        
        List<Priviliege> pivs = await _userPrivilegeUnitOfWork.GetPriviliegesRelatedToUser(userFromDb.Id);
        List<string> privNames = pivs.Select(p => p.Name).ToList();
        User? userFromDataBase = await _repository.GetById(userFromDb.Id);
        if (userFromDataBase != null)
        return new()
        {
           Value = _jwtProvider.GenrateAccessToken(userFromDb , privNames),
            ExpireAt = DateTime.UtcNow.AddMonths(_jwtAccessOptions.ExpireTimeInMonths),
            Name = userFromDataBase.Name,
            IdentityNumber = userFromDataBase.IdentityNumber,
            GovernorateId = userFromDataBase.GovernorateId,
            City = userFromDataBase.City,
            Sex = userFromDataBase.Sex,
            MobilePhoneNumber = userFromDataBase.MobilePhoneNumber,
            PhoneNumber = userFromDataBase.PhoneNumber,
            Email = userFromDataBase.Email,
            BirthDate = userFromDataBase.BirthDate,
            ImagePath = userFromDataBase.ImagePath,
            DocumentsPaths = userFromDataBase.DocumentsPaths,
            Governorate = userFromDataBase.Governorate,
            Comittee = userFromDataBase.Comittee,
        };
        else
        {
            return null;
        }
    }
    #endregion

    #region
    public async Task<User> MapFromUserRegistrationDtoToUser(UserRegistrationDto dto)
    {
        User user = new()
        {
            Email = dto.Email,
            Name = dto.Name,
            IdentityNumber = dto.IdentityNumber,
            GovernorateId = dto.GovernorateId,
            City = dto.City,
            Sex = dto.Sex,
            MobilePhoneNumber = dto.MobilePhoneNumber,
            PhoneNumber = dto.PhoneNumber,
            BirthDate = dto.BirthDate,
            Password = dto.Password,
            ComiteeId = dto.CommiteeId
        };

        string? imageName = null;

        if (dto.Image != null)
            imageName = await dto.Image.SaveImageAsync(_env);

        user.ImagePath = imageName.GetFileUrl(_contextAccessor) ?? "";
        List<string>? documentsPaths = null;
        if(dto.Documents != null && dto.Documents.Any())
        {
            documentsPaths = new();
            foreach (var document in dto.Documents)
            {
                string path = await document.SaveImageAsync(_env);
                documentsPaths.Add(path.GetFileUrl(_contextAccessor) ?? "");
            }
            user.DocumentsPaths = documentsPaths;
        } 

        return user;
    }

    #endregion
    private async Task<TokenDto> Register(User user, RoleEnum role)
    {
        
        user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);

        if (role == RoleEnum.Farmer)
        {
            user.Role = RoleEnum.Farmer;

            user.ComiteeId = null;

            List<User> employees = await _repository.GetList(q => q.Where(e => e.Role == RoleEnum.Empolyee && e.GovernorateId == user.GovernorateId));

            List<HubConnectedUser> onlineUsers = _conecctedUsers.HubConnectedUsers.Where(e => e.Role == RoleEnum.Empolyee && e.GovernorateId == user.GovernorateId)
                                                                      .ToList();

            List<Guid> onlineUsersIds = onlineUsers.Select(e => e.Id).ToList();

            List<Guid> offlineEmployeesIds = employees.Where(e => !onlineUsersIds.Contains(e.Id))
                                                   .Select(e=>e.Id)
                                                   .ToList();

            List<string> userHubIds = onlineUsers.Select(e => e.ConnectionId).ToList();

            Guid EmployeeID = _contextAccessor.GetUserId(); 
            User? UserFromDb = await _repository.GetById(EmployeeID);
            if (EmployeeID != Guid.Empty && UserFromDb != null && UserFromDb.Role == RoleEnum.Empolyee)
            {
                user.IsConfirmed = true;
            }
            else
            {

                string notifactionMessage = $"المزراع {user.Name} انشاء حساب و بانتظار الموافقة";

                foreach (var id in userHubIds)
                    await _hubContext.Clients.Client(id).ReciveNotification(notifactionMessage);

                foreach (var id in offlineEmployeesIds)
                {
                    Notifaction notifaction = new()
                    {
                        Message = notifactionMessage,
                        UserId = id,
                        SeenAt = null
                    };
                    await _notifactionRepository.Add(notifaction);
                }
            }
           
        }
        else
        {
            user.Role = RoleEnum.Empolyee;
            user.IsConfirmed = true;
        }

        await _repository.Add(user);

        Guid userId = _contextAccessor.GetUserId();
        List<Priviliege> pivs = await _userPrivilegeUnitOfWork.GetPriviliegesRelatedToUser(userId);
        List<string> privNames = pivs.Select(p => p.Name).ToList();
        return new()
        {
            Value = _jwtProvider.GenrateAccessToken(user, privNames),
            ExpireAt = DateTime.UtcNow.AddMonths(_jwtAccessOptions.ExpireTimeInMonths),
        };
    }
}
