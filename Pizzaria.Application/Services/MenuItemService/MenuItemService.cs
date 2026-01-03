using AutoMapper;
using Pizzaria.Application.Interfaces.Services.MenuItemService;
using Pizzaria.Domain.Entities;
using Pizzaria.Domain.Interfaces.Repositories.MenuRepository;
using Pizzaria.Shared.DTOs.MenuItem;
using Pizzaria.Shared.DTOs.Product;

namespace Pizzaria.Application.Services.MenuItemService
{
    public class MenuItemService : IMenuItemService
    {
        private readonly IMenuItemRepository _repository;
        private readonly IMapper _mapper;

        public MenuItemService(IMenuItemRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<MenuItemDto>> GetAllAsync()
        {
            var items = await _repository.GetAllAsync();
            return _mapper.Map<List<MenuItemDto>>(items);
        }

        public async Task<MenuItemDto?> GetByIdAsync(Guid id)
        {
            var item = await _repository.GetByIdAsync(id);
            return item == null ? null : _mapper.Map<MenuItemDto>(item);
        }

        public async Task<MenuItemDto> CreateAsync(CreateMenuItemDto dto)
        {
            var entity = _mapper.Map<MenuItem>(dto);
            var result = await _repository.AddAsync(entity);
            return _mapper.Map<MenuItemDto>(result);
        }

        public async Task UpdateAsync(Guid id, UpdateMenuItemDto dto)
        {
            var menuItem = await _repository.GetByIdAsync(id);
            if (menuItem is null)
                throw new KeyNotFoundException("Item not Found.");

            menuItem.Update(dto.Name, dto.Price, dto.Description);

            if (dto.IsActive)
                menuItem.Activate();
            else
                menuItem.Deactivate();

            await _repository.UpdateAsync(menuItem);
        }

        public async Task DeleteAsync(Guid id)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null)
                throw new KeyNotFoundException("MenuItem not found");

            await _repository.DeleteAsync(existing);
        }
    }
}
