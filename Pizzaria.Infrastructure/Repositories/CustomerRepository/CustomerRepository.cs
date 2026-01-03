using Microsoft.EntityFrameworkCore;
using Pizzaria.Domain.Interfaces.Repositories.CustomerRespository;
using Pizzaria.Infrastructure.Data;
using Pizzaria.Domain.Entities;

namespace Pizzaria.Infrastructure.Repositories.CustomerRepository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly PizzariaDbContext _context;

        public CustomerRepository(PizzariaDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await _context.Customers.Include(c => c.Addresses).ToListAsync();
        }

        public async Task<Customer?> GetByIdAsync(Guid id)
        {
            return await _context.Customers.Include(c => c.Addresses)
                                           .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task AddAsync(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Customer customer)
        {
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var customer = await GetByIdAsync(id);
            if (customer is null) return;

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
        }
    }
}
