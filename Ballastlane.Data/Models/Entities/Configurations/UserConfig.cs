using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ballastlane.Data.Models.Entities.Configurations
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(p => p.Name).HasMaxLength(120).IsRequired();
            builder.Property(p => p.Name).HasMaxLength(120).IsRequired();
            builder.Property(p => p.Name).HasMaxLength(120).IsRequired();
            builder.Property(p => p.Name).HasMaxLength(120).IsRequired();
        }
    }
}
