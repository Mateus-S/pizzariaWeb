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

            builder.OwnsMany(c => c.Addresses);
        }
    }
}