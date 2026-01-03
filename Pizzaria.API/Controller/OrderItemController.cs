using Microsoft.AspNetCore.Mvc;
using Pizzaria.Application.Interfaces;
using Pizzaria.Application.Interfaces.Services.OrderItemService;
using Pizzaria.Shared.DTOs.Order;

namespace Pizzaria.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderItemController : ControllerBase
    {
        private readonly IOrderItemService _service;

        public OrderItemController(IOrderItemService service)
        {
            _service = service;
        }

        // GET: api/orderitem
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await _service.GetAllAsync();
            return Ok(items);
        }

        // GET: api/orderitem/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var item = await _service.GetByIdAsync(id);
            return Ok(item);
        }

        // POST: api/orderitem
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateOrderItemDto dto)
        {
            await _service.CreateAsync(dto);
            return Ok(StatusCode(200));
        }

        // PUT: api/orderitem/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateOrderItemDto dto)
        {
            await _service.UpdateAsync(id, dto);
            return NoContent();
        }

        // DELETE: api/orderitem/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
