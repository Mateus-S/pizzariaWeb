using Pizzaria.Shared.DTOs.Category;

namespace Pizzaria.Application.Interfaces.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetAllAsync();
        Task<CategoryDto?> GetByIdAsync(Guid id);
        Task CreateAsync(CreateCategoryDto dto);
        Task UpdateAsync(UpdateCategoryDto dto);
        Task DeleteAsync(Guid id);
    }
}
