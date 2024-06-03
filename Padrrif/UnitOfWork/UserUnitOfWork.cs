namespace Padrrif;
public class UserUnitOfWork : UnitOfWork<User>, IUserUnitOfWork
{
    private readonly IRepository<User> _repository;
    public UserUnitOfWork(IRepository<User> repository) : base(repository){
        _repository = repository;
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
}