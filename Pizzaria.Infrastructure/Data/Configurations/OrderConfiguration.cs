using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pizzaria.Domain.Entities;

namespace Pizzaria.Infrastructure.Data.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(o => o.Id);

            builder.Property(o => o.CreatedAt)
                .IsRequired();

            builder.Property(o => o.TotalAmount)
                .HasPrecision(10, 2);

            builder.Property(o => o.Status)
                .IsRequired();

            builder.Property(o => o.DeliveryType)
                .IsRequired();

            builder.OwnsOne(o => o.DeliveryAddress);

            builder.HasMany(o => o.Items)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}