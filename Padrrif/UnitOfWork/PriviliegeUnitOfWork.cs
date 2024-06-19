using Padrrif.Entities;
using Padrrif.UnitOfWork.Interface;

namespace Padrrif.UnitOfWork
{
    public class PriviliegeUnitOfWork : UnitOfWork<Priviliege>, IPriviliegeUnitOfWork
    {
       private readonly IRepository<Priviliege> _repository;
        public PriviliegeUnitOfWork(IRepository<Priviliege> repository) :base(repository)
        {
            _repository = repository;
        }

        public async Task AddPriviliege(string priviliege)
        {
            if (priviliege == string.Empty)
                throw new ArgumentNullException("priviliege´s Name cannot be null or Empty");

            Priviliege newpriviliege = new Priviliege();
            newpriviliege.Name = priviliege;
            await _repository.Add(newpriviliege);
        }

        public async Task<List<Priviliege>> getPrivilieges()
        {
            List<Priviliege> priviliegesFromDb = await _repository.GetList();
            return priviliegesFromDb;
        }
    }
}
