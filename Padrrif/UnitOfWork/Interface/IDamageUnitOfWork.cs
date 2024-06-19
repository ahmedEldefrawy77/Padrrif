namespace Padrrif.UnitOfWork.Interface;

public interface IDamageUnitOfWork : IUnitOfWork<Damage>
{
    Task<List<Damage>> GetFramerDamages();
    Task<List<Damage>> GetDamageForEmpolyee();
    Task<Damage> MapFromDamageDtoToDamage(DamageDto dto);
}
