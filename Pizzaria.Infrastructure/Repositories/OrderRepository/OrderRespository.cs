using Microsoft.EntityFrameworkCore;
using Pizzaria.Domain.Interfaces.Repositories.OrderRepository;
using Pizzaria.Infrastructure.Data;

namespace Pizzaria.Infrastructure.Repositories.OrderRepository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly PizzariaDbContext _context;

        public OrderRepository(PizzariaDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Order order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await _context.Orders
                .Include(o => o.Items)
                .Include(o => o.Customer)
                .Include(o => o.Attendant)
                .Include(o => o.DeliveryAddress)
                .ToListAsync();
        }

        public async Task<Order?> GetByIdAsync(Guid id)
        {
            return await _context.Orders
                .Include(o => o.Items)
                .Include(o => o.Customer)
                .Include(o => o.Attendant)
                .Include(o => o.DeliveryAddress)
                .FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task UpdateAsync(Order order)
        {
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order is not null)
            {
                _context.Orders.Remove(order);
                await _context.SaveChangesAsync();
            }
        }
    }
}
