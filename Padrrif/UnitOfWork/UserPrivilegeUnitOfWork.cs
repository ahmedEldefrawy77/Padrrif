using Padrrif.Entities;
using Padrrif.UnitOfWork.Interface;

namespace Padrrif.UnitOfWork
{
    public class UserPrivilegeUnitOfWork : UnitOfWork<EmployeePrivilieges>, IUserPrivilegeUnitOfWork
    {
        private readonly IRepository<EmployeePrivilieges> _employeePriviliegesRepository;
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Priviliege> _priviliegeRepository;
        public UserPrivilegeUnitOfWork(IRepository<EmployeePrivilieges> repository, IRepository<User> userRepository, IRepository<Priviliege> priviliegeRepository) 
            : base(repository)
        {
            _employeePriviliegesRepository = repository;
            _userRepository = userRepository;
            _priviliegeRepository = priviliegeRepository;
        }

        public async Task AddPrivilegeToUser(Guid PrivilegeId, Guid UserId)
        {
            if(PrivilegeId == Guid.Empty || UserId == Guid.Empty)
                throw new ArgumentNullException("something went wrong either Privilege Id or User Id is Empty");

            User? UserFromDb = await _userRepository.GetById(UserId);
            if (UserFromDb == null)
                throw new ArgumentException("wrong Credentials, User id cannot be null");

            Priviliege? PrivilegeFromDb = await _priviliegeRepository.GetById(PrivilegeId);
            if (PrivilegeFromDb == null)
                throw new ArgumentException("wrong Privilege id");

           EmployeePrivilieges EmployeePrivilege = new EmployeePrivilieges();
            EmployeePrivilege.PrivliegeId = PrivilegeId;
            EmployeePrivilege.EmployeeId = UserId;

            await _employeePriviliegesRepository.Add(EmployeePrivilege);
        }

        public Task DeletePrivilegeFromUser(Guid PrivilegeId, Guid UserId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Priviliege>> GetPriviliegesRelatedToUser(Guid UserId)
        {
            List<EmployeePrivilieges>? employeePriv = await _employeePriviliegesRepository.GetList(q => q.Where(u => u.EmployeeId == UserId));
            if (employeePriv == null)
                throw new ArgumentNullException("no Priviliege assocciated with this User Id, or wronge Credentials");

            List<Guid> privIds = employeePriv.Select(u => u.PrivliegeId).ToList();

            List<Priviliege> privs = new List<Priviliege>();
           
            for (int i = 0; i < privIds.Count; i++)
            {
                privs.Add(await _priviliegeRepository.GetById(privIds[i]));
            }
            return privs;
         }
    }
}
