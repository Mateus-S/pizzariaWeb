using Microsoft.EntityFrameworkCore;
using Pizzaria.Domain.Entities;
using Pizzaria.Domain.Interfaces.Repositories.MenuRepository;
using Pizzaria.Infrastructure.Data;

namespace Pizzaria.Infrastructure.Repositories.MenuItemRepository
{
    public class MenuItemRepository : IMenuItemRepository
    {
        private readonly PizzariaDbContext _context;

        public MenuItemRepository(PizzariaDbContext context)
        {
            _context = context;
        }

        public async Task<List<MenuItem>> GetAllAsync() =>
            await _context.MenuItems
            .Include(m => m.Category)
            .AsNoTracking()
            .ToListAsync();

        public async Task<MenuItem?> GetByIdAsync(Guid id) =>
            await _context.MenuItems.FindAsync(id);

        public async Task<MenuItem> AddAsync(MenuItem entity)
        {
            _context.MenuItems.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(MenuItem entity)
        {
            _context.MenuItems.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(MenuItem entity)
        {
            _context.MenuItems.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
