using Pizzaria.Shared.DTOs.MenuItem;
using Pizzaria.Shared.DTOs.Product;

namespace Pizzaria.WEB.Services.Interfaces
{
    public interface IMenuItemService
    {
        /// <summary>
        /// Obtém todos os itens do cardápio.
        /// </summary>
        Task<List<MenuItemDto>> GetAllAsync();

        /// <summary>
        /// Cria um novo item de cardápio.
        /// </summary>
        Task<bool> CreateAsync(CreateMenuItemDto dto);

        /// <summary>
        /// Atualiza um item de cardápio existente.
        /// </summary>
        Task<bool> UpdateAsync(UpdateMenuItemDto dto);

        /// <summary>
        /// Alterna o status (ativo/inativo) de um item do cardápio.
        /// </summary>
        Task<bool> ToggleStatusAsync(Guid id);
    }
}
