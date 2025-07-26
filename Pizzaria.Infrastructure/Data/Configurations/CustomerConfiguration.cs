using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pizzaria.Domain.Entities;

namespace Pizzaria.Infrastructure.Data.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.FullName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.PhoneNumber)
                .IsRequired()
                .HasMaxLength(15);

            builder.Property(c => c.Notes)
                .HasMaxLength(255);

            builder.OwnsMany(c => c.Addresses, a =>
            {
                a.WithOwner().HasForeignKey("CustomerId"); // cria FK manual
                a.ToTable("CustomerAddresses"); // nome mais claro

                a.HasKey("CustomerId", "ZipCode", "Street", "Number"); // chave composta

                a.Property(p => p.Street).IsRequired().HasMaxLength(100);
                a.Property(p => p.Number).IsRequired().HasMaxLength(10);
                a.Property(p => p.Neighborhood).IsRequired().HasMaxLength(50);
                a.Property(p => p.City).IsRequired().HasMaxLength(50);
                a.Property(p => p.State).IsRequired().HasMaxLength(2);
                a.Property(p => p.ZipCode).IsRequired().HasMaxLength(10);
                a.Property(p => p.Complement).HasMaxLength(100);
            });
        }
    }
}

