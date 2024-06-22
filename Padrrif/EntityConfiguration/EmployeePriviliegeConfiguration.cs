

namespace Padrrif.EntityConfiguration
{
    public class EmployeePriviliegeConfiguration : IEntityTypeConfiguration<EmployeePrivilieges>
    {
        public void Configure(EntityTypeBuilder<EmployeePrivilieges> builder)
        {
            builder
                 .HasKey(e => new { e.EmployeeId, e.PrivliegeId });

            builder.Property(e => e.Id).HasValueGenerator<GuidValueGenerator>();

            builder
                .HasOne(e => e.User)
                .WithMany(e => e.EmployeePrivilieges)
                .HasForeignKey(e => e.EmployeeId);
            builder
                .HasOne(e => e.Priviliege)
                .WithMany(e => e.EmployeePrivilieges)
                .HasForeignKey(e => e.PrivliegeId);
        }
    }
}
