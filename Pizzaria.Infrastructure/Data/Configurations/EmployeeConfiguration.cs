using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pizzaria.Domain.Entities;

namespace Pizzaria.Infrastructure.Data.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.FullName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.DocumentNumber)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(e => e.Role)
                .IsRequired();

            builder.Property(e => e.IsActive)
                .IsRequired();
        }
    }
}