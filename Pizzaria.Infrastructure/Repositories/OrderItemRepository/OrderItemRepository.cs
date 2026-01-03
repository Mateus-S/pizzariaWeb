using Microsoft.EntityFrameworkCore;
using Pizzaria.Domain.Interfaces.Repositories.OrderItemRepository;
using Pizzaria.Infrastructure.Data;

namespace Pizzaria.Infrastructure.Repositories.OrderItemRepository
{
    // Infrastructure.Repositories
    public class OrderItemRepository : IOrderItemRepository
    {
        private readonly PizzariaDbContext _context;

        public OrderItemRepository(PizzariaDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<OrderItem>> GetAllAsync()
        {
            return await _context.OrderItems.ToListAsync();
        }

        public async Task<OrderItem?> GetByIdAsync(Guid id)
        {
            return await _context.OrderItems.FindAsync(id);
        }

        public async Task AddAsync(OrderItem orderItem)
        {
            await _context.OrderItems.AddAsync(orderItem);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(OrderItem orderItem)
        {
            _context.OrderItems.Update(orderItem);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await GetByIdAsync(id);
            if (entity is not null)
            {
                _context.OrderItems.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }

}
