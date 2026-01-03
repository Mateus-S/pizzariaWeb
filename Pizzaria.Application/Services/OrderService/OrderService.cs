using AutoMapper;
using Pizzaria.Application.Interfaces.Services.OrderService;
using Pizzaria.Shared.Enums;
using Pizzaria.Domain.Interfaces.Repositories.OrderRepository;
using Pizzaria.Shared.DTOs.Order;
using Pizzaria.Domain.Enums;

namespace Pizzaria.Application.Services.OrderService
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OrderDto>> GetAllAsync()
        {
            var orders = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<OrderDto>>(orders);
        }

        public async Task<OrderDto?> GetByIdAsync(Guid id)
        {
            var order = await _repository.GetByIdAsync(id);
            return order is null ? null : _mapper.Map<OrderDto>(order);
        }

        public async Task AddAsync(CreateOrderDto dto)
        {
            var order = new Order(dto.CustomerId, null, (Domain.Enums.DeliveryType)dto.DeliveryType, null, null);

            foreach (var item in dto.Items)
            {
                var newItem = new OrderItem(item.MenuItemId, item.Quantity, item.UnitPrice, item.Notes);
                order.AddItem(newItem);
            }

            await _repository.AddAsync(order);
        }

        public async Task UpdateStatusAsync(UpdateOrderDto dto)
        {
            var order = await _repository.GetByIdAsync(dto.Id);
            if (order is not null &&
                Enum.TryParse<OrderStatus>(dto.Status, ignoreCase: true, out var newStatus))
            {
                order.UpdateStatus(newStatus);
                await _repository.UpdateAsync(order);
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
