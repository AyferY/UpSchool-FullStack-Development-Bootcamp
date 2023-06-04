using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UpStorage.Domain.Entities;

namespace UpStorage.Infrastructure.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            // ID
            builder.HasKey(x => x.Id);

            //CreatedOn
            builder.Property(x => x.CreatedOn).IsRequired();

            // RequestedAmount
            builder.Property(x => x.RequestedAmount).IsRequired();
            builder.Property(x => x.RequestedAmount).HasColumnType("int");

            // TotalFoundAmount
            builder.Property(x => x.TotalFoundAmount).IsRequired();
            builder.Property(x => x.TotalFoundAmount).HasColumnType("int");

            // ProductCrawlType
            builder.Property(x => x.ProductCrawlType).IsRequired();

            builder.HasMany<Product>(x => x.Products)
                .WithOne(x => x.Order)
                .HasForeignKey(x => x.OrderId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany<OrderEvent>(x => x.OrderEvents)
                .WithOne(x => x.Order)
                .HasForeignKey(x => x.OrderId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            //Table Name
            builder.ToTable("Orders");
        }
    }
}