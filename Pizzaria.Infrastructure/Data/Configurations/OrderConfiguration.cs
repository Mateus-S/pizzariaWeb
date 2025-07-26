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

            builder.Property(o => o.Notes)
                .HasMaxLength(500);

            builder.HasOne(o => o.Customer)
                .WithMany()
                .HasForeignKey(o => o.CustomerId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(o => o.Attendant)
                .WithMany()
                .HasForeignKey(o => o.AttendantId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(o => o.Items)
                .WithOne(i => i.Order)
                .HasForeignKey(i => i.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.OwnsOne(o => o.DeliveryAddress, da =>
            {
                da.Property(a => a.Street).HasColumnName("Delivery_Street").IsRequired();
                da.Property(a => a.Number).HasColumnName("Delivery_Number").IsRequired();
                da.Property(a => a.Neighborhood).HasColumnName("Delivery_Neighborhood").IsRequired();
                da.Property(a => a.City).HasColumnName("Delivery_City").IsRequired();
                da.Property(a => a.Reference).HasColumnName("Delivery_Reference").IsRequired();
            });
        }
    }
}
