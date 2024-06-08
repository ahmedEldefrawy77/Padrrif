namespace Padrrif;

public interface IUserUnitOfWork : IUnitOfWork<User>
{
    Task<List<User>> GetAllUnConfirmedUsers();
    Task<bool> ConfirmUser(int userId);
    Task<List<User>?> GetAllUserBasedOnStatuse(int userenum);
    Task<User?> GetUserWithIdentityNumber(int id);
    Task<List<User>?> GetUserWithName(string name);
    Task<string> UpdateUser(User user);

}
