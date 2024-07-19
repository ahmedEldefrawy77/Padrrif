using Padrrif.Entities;

namespace Padrrif.EntityConfiguration
{
    public class DamageReportConfiguration : BaseEntityConfiguration<DamageReport>
    {

        public override void Configure(EntityTypeBuilder<DamageReport> builder)
        {
           base.Configure(builder);
            builder.Property(e => e.Name).IsRequired();
            builder.Property(e=>e.Description).IsRequired();
            builder.Property(e=>e.CurrentStage).IsRequired();   
       
        }
    }
}
