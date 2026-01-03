using Microsoft.EntityFrameworkCore;
using Pizzaria.Domain.Entities;
using Pizzaria.Domain.Interfaces.Repositories.CategoryRepository;
using Pizzaria.Infrastructure.Data;

namespace Pizzaria.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly PizzariaDbContext _context;

        public CategoryRepository(PizzariaDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
            => await _context.Categories.ToListAsync();

        public async Task<Category?> GetByIdAsync(Guid id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public async Task AddAsync(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Category category)
        {
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _context.Categories.FindAsync(id);
            if (entity is null) return;

            _context.Categories.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
