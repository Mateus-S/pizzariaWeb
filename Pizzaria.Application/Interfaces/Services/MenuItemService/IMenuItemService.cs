using Pizzaria.Shared.DTOs.MenuItem;
using Pizzaria.Shared.DTOs.Product;

namespace Pizzaria.Application.Interfaces.Services.MenuItemService
{
    public interface IMenuItemService
    {
        Task<List<MenuItemDto>> GetAllAsync();
        Task<MenuItemDto?> GetByIdAsync(Guid id);
        Task<MenuItemDto> CreateAsync(CreateMenuItemDto dto);
        Task UpdateAsync(Guid id, UpdateMenuItemDto dto);
        Task DeleteAsync(Guid id);
    }
}
