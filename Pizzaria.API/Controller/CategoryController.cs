using Microsoft.AspNetCore.Mvc;
using Pizzaria.Application.Interfaces.Services;
using Pizzaria.Shared.DTOs.Category;

namespace Pizzaria.API.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _service;

        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id) =>
            Ok(await _service.GetByIdAsync(id));

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCategoryDto dto)
        {
            await _service.CreateAsync(dto);
            return Ok(StatusCode(200));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] UpdateCategoryDto dto)
        {
            await _service.UpdateAsync(dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }

}
