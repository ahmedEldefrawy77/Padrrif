﻿using Padrrif.EntityConfiguration;

namespace Padrrif;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration())
                    .ApplyConfiguration(new GovernorateConfiguration())
                    .ApplyConfiguration(new AnimalDamageConfiguration())
                    .ApplyConfiguration(new ComitteeConfiguration())
                    .ApplyConfiguration(new DamageConfiguration())
                    .ApplyConfiguration(new EducationLevelConfiguration())
                    .ApplyConfiguration(new FarmFacilitiesConfiguration())
                    .ApplyConfiguration(new FisheryDamageConfiguration())
                    .ApplyConfiguration(new OwnerShipTypeConfiguration())
                    .ApplyConfiguration(new PlantDamageConfiguration())
                    .ApplyConfiguration(new VillageConfiguration())
                    .ApplyConfiguration(new WorkHoursConfiguration())
                    .ApplyConfiguration(new NotifactionConfiguration())
                    .ApplyConfiguration(new EmployeePriviliegeConfiguration())
                    .ApplyConfiguration(new PriviliegeConfiguration())
                    .ApplyConfiguration(new DamageReportConfiguration())
                    .ApplyConfiguration(new ActivityLogConfiguration());
    }
}
