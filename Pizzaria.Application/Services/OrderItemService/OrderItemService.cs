using AutoMapper;
using Pizzaria.Application.Interfaces.Services.OrderItemService;
using Pizzaria.Domain.Enums;
using Pizzaria.Domain.Interfaces.Repositories.OrderItemRepository;
using Pizzaria.Shared.DTOs.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzaria.Application.Services.OrderItemService
{
    // Application.Services
    public class OrderItemService : IOrderItemService
    {
        private readonly IOrderItemRepository _repository;
        private readonly IMapper _mapper;

        public OrderItemService(IOrderItemRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OrderItemDto>> GetAllAsync()
        {
            var items = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<OrderItemDto>>(items);
        }

        public async Task<OrderItemDto?> GetByIdAsync(Guid id)
        {
            var item = await _repository.GetByIdAsync(id);
            return item is null ? null : _mapper.Map<OrderItemDto>(item);
        }

        public async Task CreateAsync(CreateOrderItemDto dto)
        {
            var entity = _mapper.Map<OrderItem>(dto);
            await _repository.AddAsync(entity);
        }

        public async Task UpdateAsync(Guid id, UpdateOrderItemDto dto)
        {
            var item = await _repository.GetByIdAsync(id);
            if (item is null)
                throw new Exception("Item de pedido não encontrado.");

            item.UpdateQuantity(dto.Quantity);
            item.UpdateUnitPrice(dto.UnitPrice);
            item.UpdateNotes(dto.Notes ?? string.Empty);

            await _repository.UpdateAsync(item);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _repository.DeleteAsync(id);
        }
    }

}
