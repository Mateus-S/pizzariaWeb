using Pizzaria.Domain.Entities;

namespace Pizzaria.Domain.Interfaces.Repositories.CategoryRepository
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllAsync();
        Task<Category?> GetByIdAsync(Guid id);
        Task AddAsync (Category category);
        Task UpdateAsync (Category category);
        Task DeleteAsync (Guid id);

    }
}
