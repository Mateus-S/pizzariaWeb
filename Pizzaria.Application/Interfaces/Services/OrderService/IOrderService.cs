using Pizzaria.Shared.DTOs.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzaria.Application.Interfaces.Services.OrderService
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderDto>> GetAllAsync();
        Task<OrderDto?> GetByIdAsync(Guid id);
        Task AddAsync(CreateOrderDto dto);
        Task UpdateStatusAsync(UpdateOrderDto dto);
        Task DeleteAsync(Guid id);
    }
}
