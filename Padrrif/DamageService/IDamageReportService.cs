namespace Padrrif.DamageService
{
    public interface IDamageReportService
    {
        Task<Damage> UpdateDamageReportStatuse(Guid damageReportId, IFormFileCollection SignatureImage);
        Task<Damage> UpdateDamageReportStatuseFirstCheck(Guid damageReportId, string statuse);
    }
}
