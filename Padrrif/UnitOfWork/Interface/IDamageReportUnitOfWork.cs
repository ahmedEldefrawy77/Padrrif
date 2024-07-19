using Padrrif.Entities;

namespace Padrrif.UnitOfWork.Interface
{
    public interface IDamageReportUnitOfWork : IUnitOfWork<DamageReport>
    {
        Task<string> AddDamageReport(string name, string description);
        Task<DamageReport> UpdateDamageReport(Guid id, IFormFileCollection SignatureImage);
    }
}
