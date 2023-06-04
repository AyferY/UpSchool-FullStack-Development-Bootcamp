using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UpStorage.Domain.Entities;

namespace UpStorage.Infrastructure.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            // ID
            builder.HasKey(x => x.Id);

            // Name
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Name).HasMaxLength(200);
            builder.HasIndex(x => x.Name);

            builder.Property(x => x.OrderId).IsRequired();
            // Picture
            builder.Property(x => x.Picture).IsRequired();
            builder.Property(x => x.Picture).HasMaxLength(200);

            
            // IsOnSale
            builder.Property(x => x.IsOnSale).IsRequired();

            // Price
            builder.Property(x => x.Price).IsRequired();
            builder.Property(x => x.Price).HasColumnType("decimal(10,4)");

            // SalePrice
            builder.Property(x => x.SalePrice).IsRequired();
            builder.Property(x => x.SalePrice).HasColumnType("decimal(10,4)");

            builder.Property(x => x.CreatedOn).IsRequired();

            builder.ToTable("Products");
        }
    }
}
