using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ballastlane.Data.Models.Entities.Configurations
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Name).HasMaxLength(120).IsRequired();
            builder.Property(p => p.Brand).HasMaxLength(120).IsRequired();
            builder.Property(p => p.Type).HasMaxLength(15).IsRequired();
            builder.Property(p => p.Price).HasPrecision(precision: 10, scale: 2);
            builder.Property(p => p.SellingPrice).HasPrecision(precision: 10, scale: 2);
        }
    }
}
