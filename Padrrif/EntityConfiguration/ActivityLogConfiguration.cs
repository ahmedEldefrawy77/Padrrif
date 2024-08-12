using Padrrif.Entities;

namespace Padrrif.EntityConfiguration
{
    public class ActivityLogConfiguration : BaseEntityConfiguration<ActivityLog>
    {
        public override void Configure(EntityTypeBuilder<ActivityLog> builder) 
        {
            base.Configure(builder);
            builder.Property(e=>e.ActivityType).IsRequired();
            builder.Property(e=>e.UserId).IsRequired();
            builder.Property(e=>e.TimeStamp).IsRequired();
        }
    }
}
