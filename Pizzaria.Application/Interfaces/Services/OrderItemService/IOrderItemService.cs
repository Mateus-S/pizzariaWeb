using Pizzaria.Shared.DTOs.Order;

namespace Pizzaria.Application.Interfaces.Services.OrderItemService
{
    public interface IOrderItemService
    {
        Task<IEnumerable<OrderItemDto>> GetAllAsync();
        Task<OrderItemDto?> GetByIdAsync(Guid id);
        Task CreateAsync(CreateOrderItemDto dto);
        Task UpdateAsync(Guid id, UpdateOrderItemDto dto);
        Task DeleteAsync(Guid id);
    }
}
