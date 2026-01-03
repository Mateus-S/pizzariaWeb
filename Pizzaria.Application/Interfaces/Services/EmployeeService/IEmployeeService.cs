using Pizzaria.Shared.DTOs.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzaria.Application.Interfaces.Services.EmployeeService
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDto>> GetAllAsync();
        Task<EmployeeDto?> GetByIdAsync(Guid id);
        Task AddAsync(CreateEmployeeDto dto);
        Task UpdateAsync(UpdateEmployeeDto dto);
        Task DeleteAsync(Guid id);
    }
}
