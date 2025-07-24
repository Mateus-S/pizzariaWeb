using Microsoft.EntityFrameworkCore;
using Pizzaria.Domain.Entities;

namespace Pizzaria.Infrastructure.Data
{
    public class PizzariaDbContext : DbContext
    {
        public PizzariaDbContext(DbContextOptions<PizzariaDbContext> options)
            : base(options) { }

        public DbSet<Order> Orders => Set<Order>();
        public DbSet<OrderItem> OrderItems => Set<OrderItem>();
        public DbSet<Product> Products => Set<Product>();
        public DbSet<Customer> Customers => Set<Customer>();
        public DbSet<User> Users => Set<User>();
        public DbSet<Employee> Employees => Set<Employee>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Aplica todas as configurações de mapeamento (caso tenha separado por Fluent API)
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PizzariaDbContext).Assembly);
        }
    }
}
