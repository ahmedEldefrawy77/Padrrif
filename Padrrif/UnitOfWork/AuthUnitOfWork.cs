using Microsoft.AspNetCore.Http.HttpResults;
using Padrrif.Dto;
using Padrrif.Entities;
using Padrrif.Services.PicServices;
using Padrrif.UnitOfWork.Interface;
using System.Reflection.Metadata;

namespace Padrrif;
public class AuthUnitOfWork : IAuthUnitOfWork
{
    private readonly IRepository<User> _repository;
    private readonly IRepository<ActivityLog> _ActivityRepository;
    private readonly IWebHostEnvironment _env;
    private readonly IHttpContextAccessor _contextAccessor;
    private readonly IJwtProvider _jwtProvider;
    private readonly JwtAccessOptions _jwtAccessOptions;
    private readonly IHubContext<NotificationHub, INotificationClient> _hubContext;
    private readonly NotificationHubConecctedUsers _conecctedUsers;
    private readonly IRepository<Notifaction> _notifactionRepository;
    private readonly IUserPrivilegeUnitOfWork _userPrivilegeUnitOfWork;
    private readonly TimeZoneInfo _timeZone;

    public AuthUnitOfWork(IRepository<User> repository,IRepository<ActivityLog> activityLog, IWebHostEnvironment env,
        IHttpContextAccessor contextAccessor, IJwtProvider jwtProvider, IOptions<JwtAccessOptions> jwtAccessOption,
        IHubContext<NotificationHub, INotificationClient> hubContext, NotificationHubConecctedUsers conecctedUsers, IRepository<Notifaction> notifactionRepository,
        IUserPrivilegeUnitOfWork userPrivilegeUnitOfWork,
        IImageService imageService, TimeZoneInfo timeZone)
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
        _timeZone = TimeZoneInfo.FindSystemTimeZoneById("West Bank Standard Time");
        _ActivityRepository = activityLog;
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
        {
            ActivityLog activityLog = new ActivityLog();

            activityLog.UserId = userFromDb.IdentityNumber;
                activityLog.ActivityType = "Farmer Registeration";
                activityLog.Name = userFromDb.Name + " " + userFromDb.FatherName + " " + userFromDb.FamilyFather;
                activityLog.TimeStamp = TimeZoneInfo.ConvertTime(DateTime.UtcNow, _timeZone);
            await _ActivityRepository.Add(activityLog);
            return new()
            {
                Value = _jwtProvider.GenrateAccessToken(userFromDb, privNames),
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
        }
           
        else
        {
            return null;
        }
    }
    #endregion

    #region
    public async Task<User> MapFromFarmerRegDtoToUser(FarmerRegDto dto)
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
        if (dto.IdCard != null && dto.IdCard.Any() && dto.ProofOfOwnerShip  != null && dto.ProofOfOwnerShip.Any())
        {
            documentsPaths = new();
            foreach (var document in dto.IdCard)
            {
                string path = await document.SaveImageAsync(_env);
                documentsPaths.Add(path.GetFileUrl(_contextAccessor) ?? "");
            }
            foreach(var doc in dto.ProofOfOwnerShip)
            {
                string path = await doc.SaveImageAsync(_env);
                documentsPaths.Add(path.GetFileUrl(_contextAccessor) ?? "");
            }
            IFormFile? docu = dto.SignatureImage;

            string signatureImagePath = await docu.SaveImageAsync(_env);

            documentsPaths.Add(signatureImagePath.GetFileUrl(_contextAccessor) ?? "");

            user.DocumentsPaths = documentsPaths;
        }
        ActivityLog activityLog = new ActivityLog()
        {
            UserId = dto.IdentityNumber,
            ActivityType = "Farmer Registeration",
            Name = dto.Name,
            TimeStamp = TimeZoneInfo.ConvertTime(DateTime.UtcNow, _timeZone),
        };
       await _ActivityRepository.Add(activityLog);
        
        
        return user;
    }
    public async Task<User> MapFromUserRegistrationDtoToUser(EmployeeRegDto dto)
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
            ComiteeId = dto.CommiteeId,
            FatherName = dto.FatherName,
            GrandFather = dto.GrandFather,
            FamilyFather = dto.FamilyFather,
            NameInEnglish = dto.NameInEnglish,
            Section = dto.Section,
            PublicGovernment = dto.PublicGovernment,
            Unit = dto.Unit,
            JobTitle = dto.JobTitle,
            JobNo = dto.JobNo,
            Salary = dto.Salary,
            BankName = dto.BankName,
            IBAN = dto.IBAN,
            WorkStartedIn = dto.WorkStartedIn,
        };

        string? imageName = null;

        if (dto.Image != null)
            imageName = await dto.Image.SaveImageAsync(_env);

        user.ImagePath = imageName.GetFileUrl(_contextAccessor) ?? "";

        string? SignatureName = null;
        if (dto.SignatureImage != null)
            SignatureName = await dto.SignatureImage.SaveImageAsync(_env);

        user.SignaturePath = SignatureName.GetFileUrl(_contextAccessor) ?? "";

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

        ActivityLog activityLog = new ActivityLog()
        {
            UserId = dto.IdentityNumber,
            ActivityType = "Farmer Registeration",
            Name = dto.Name,
            TimeStamp = TimeZoneInfo.ConvertTime(DateTime.UtcNow, _timeZone),
        };
        await _ActivityRepository.Add(activityLog);

        return user;
    }

    #endregion
    private async Task<TokenDto> Register(User user, RoleEnum role)
    {
        
        user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);

        User? userFromDb = await _repository.GetSingleEntityWithSomeCondiition(e => e.Where(e => e.Email == user.Email));

        if (userFromDb != null)
            throw new ArgumentException(nameof(user.Email), "this Email has been used before, try another Email");

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
