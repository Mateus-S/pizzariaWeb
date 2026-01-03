using AutoMapper;
using Pizzaria.Application.Interfaces.Services;
using Pizzaria.Domain.Entities;
using Pizzaria.Domain.Interfaces.Repositories;
using Pizzaria.Domain.Interfaces.Repositories.CategoryRepository;
using Pizzaria.Shared.DTOs.Category;

namespace Pizzaria.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryDto>> GetAllAsync()
        {
            var categories = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<CategoryDto>>(categories);
        }

        public async Task<CategoryDto?> GetByIdAsync(Guid id)
        {
            var category = await _repository.GetByIdAsync(id);
            return category is null ? null : _mapper.Map<CategoryDto>(category);
        }

        public async Task CreateAsync(CreateCategoryDto dto)
        {
            var category = _mapper.Map<Category>(dto);
            await _repository.AddAsync(category);
        }

        public async Task UpdateAsync(UpdateCategoryDto dto)
        {
            var category = await _repository.GetByIdAsync(dto.Id);
            if (category == null) return;

            category = _mapper.Map(dto, category);
            await _repository.UpdateAsync(category);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
