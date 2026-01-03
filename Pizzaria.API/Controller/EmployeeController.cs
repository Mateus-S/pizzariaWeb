using Microsoft.AspNetCore.Mvc;
using Pizzaria.Application.Interfaces;
using Pizzaria.Application.Interfaces.Services.EmployeeService;
using Pizzaria.Shared.DTOs.Employee;

namespace Pizzaria.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _service;

        public EmployeeController(IEmployeeService service)
        {
            _service = service;
        }

        // GET: api/employee
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var employees = await _service.GetAllAsync();
            return Ok(employees);
        }

        // GET: api/employee/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var employee = await _service.GetByIdAsync(id);
            return Ok(employee);
        }

        // POST: api/employee
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateEmployeeDto dto)
        {
            await _service.AddAsync(dto);
            return Ok(StatusCode(200));
        }

        // PUT: api/employee/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] UpdateEmployeeDto dto)
        {
            await _service.UpdateAsync(dto);
            return NoContent();
        }

        // DELETE: api/employee/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
