namespace Padrrif;
public class UserUnitOfWork : UnitOfWork<User>, IUserUnitOfWork
{
    private readonly IRepository<User> _repository;
    private readonly IHttpContextAccessor _contextAccessor;
    public UserUnitOfWork(IRepository<User> repository,
        IHttpContextAccessor contextAccessor) : base(repository){
        _repository = repository;
        _contextAccessor = contextAccessor;
    }

    public async Task<List<User>> GetAllUnConfirmedUsers()
    {
        List<User> users = await Read(q => q.Where(e => e.IsConfirmed == false));
        return users;
    }

    public async Task<bool> ConfirmUser(int userId)
    {
        User? userFromDb = await _repository.GetSingleEntityWithSomeCondiition(q => q.Where(u => u.IdentityNumber == userId));

        if (userFromDb == null)
            return false;

        userFromDb.IsConfirmed = true;

        try
        {
            await Update(userFromDb);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public async Task<List<User>?> GetAllUserBasedOnStatuse(int userenum)
    {
        Guid userId = _contextAccessor.GetUserId();
        User? userFromDb = await _repository.GetById(userId);
        if (userFromDb == null)
            throw new SecurityTokenArgumentException("invalid Token");
        
        List<User>? users = null;
        RoleEnum role = (RoleEnum)userenum;

        if( userFromDb != null)
        users  = await _repository.GetList(q => q.Where(e => e.Role == role && e.City == userFromDb.City));

        return users;
    }

    public async Task<User?> GetUserWithIdentityNumber(int id)
    {
        User? userFromDb = null;
        userFromDb = await _repository.GetSingleEntityWithSomeCondiition(q => q.Where(e => e.IdentityNumber == id));
        return userFromDb;
    }

    public async Task<List<User>?> GetUserWithName(string name)
    {
        List<User>? userFromDb = null;
        userFromDb = await _repository.GetList(q=> q.Where(e => e.Name == name));
        return userFromDb;
    }
    public async Task<string> UpdateUser(User user)
    {
        Guid id =  _contextAccessor.GetUserId();
        string res = string.Empty; 

        User? UserFromDb = await _repository.GetSingleEntityWithSomeCondiition(q=>q.Where(e => e.Id == id));
        if (UserFromDb == null)
           return res = "wronge Credintials";

        if (user.Name != null)
          UserFromDb.Name = user.Name;
        
        if(user.Email != null)
        UserFromDb.Email = user.Email;

        if (user.PhoneNumber != null)
            UserFromDb.PhoneNumber = user.PhoneNumber;

        if(user.Password != null)
        UserFromDb.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);

        if (user.City != null)
            UserFromDb.City = user.City;

        if(user.ImagePath != null)
            UserFromDb.ImagePath = user.ImagePath;
        
        if(user.Governorate != null)
            UserFromDb.Governorate = user.Governorate;

        await _repository.Update(UserFromDb);

        return res = "User has been updated successfully";
    }
}