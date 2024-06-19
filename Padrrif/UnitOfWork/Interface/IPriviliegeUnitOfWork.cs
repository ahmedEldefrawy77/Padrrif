using Padrrif.Entities;

namespace Padrrif.UnitOfWork.Interface
{
    public interface IPriviliegeUnitOfWork : IUnitOfWork<Priviliege>
    {
        Task<List<Priviliege>> getPrivilieges();
        Task AddPriviliege(string priviliege);
    }
}
