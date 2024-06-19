using Padrrif.Entities;

namespace Padrrif.EntityConfiguration
{
    public class PriviliegeConfiguration : BaseEntityConfiguration<Priviliege>
    {
        public override void Configure(EntityTypeBuilder<Priviliege> builder)
        {
            base.Configure(builder);

            builder.Property(e => e.Name)
                   .HasMaxLength(100)
                   .IsRequired();
        }
    }
}
