using Padrrif.Entities;

namespace Padrrif.UnitOfWork.Interface
{
    public interface IUserPrivilegeUnitOfWork
    {
        Task AddPrivilegeToUser (Guid PrivilegeId, Guid UserId);
        Task DeletePrivilegeFromUser(Guid PrivilegeId, Guid UserId);
        Task<List<Priviliege>> GetPriviliegesRelatedToUser(Guid UserId);
    }
}
