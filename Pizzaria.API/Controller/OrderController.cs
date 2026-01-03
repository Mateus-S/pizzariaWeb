using Microsoft.AspNetCore.Mvc;
using Pizzaria.Application.Interfaces;
using Pizzaria.Application.Interfaces.Services.OrderService;
using Pizzaria.Shared.DTOs.Order;

namespace Pizzaria.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _service;

        public OrderController(IOrderService service)
        {
            _service = service;
        }

        // GET: api/order
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var orders = await _service.GetAllAsync();
            return Ok(orders);
        }

        // GET: api/order/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var order = await _service.GetByIdAsync(id);
            return Ok(order);
        }

        // POST: api/order
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateOrderDto dto)
        {
            await _service.AddAsync(dto);
            return Ok(StatusCode(200));
        }

        // PUT: api/order/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateOrderDto dto)
        {
            await _service.UpdateStatusAsync(dto);
            return NoContent();
        }

        // DELETE: api/order/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
