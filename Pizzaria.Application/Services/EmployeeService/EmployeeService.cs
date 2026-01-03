using AutoMapper;
using Pizzaria.Application.Interfaces.Services.EmployeeService;
using Pizzaria.Domain.Entities;
using Pizzaria.Domain.Interfaces.Repositories.EmployeeRespository;
using Pizzaria.Shared.DTOs.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzaria.Application.Services.EmployeeService
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repository;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task AddAsync(CreateEmployeeDto dto)
        {
            var employee = _mapper.Map<Employee>(dto);
            await _repository.AddAsync(employee);
        }

        public async Task<IEnumerable<EmployeeDto>> GetAllAsync()
        {
            var employees = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<EmployeeDto>>(employees);
        }

        public async Task<EmployeeDto?> GetByIdAsync(Guid id)
        {
            var employee = await _repository.GetByIdAsync(id);
            return employee is null ? null : _mapper.Map<EmployeeDto>(employee);
        }

        public async Task UpdateAsync(UpdateEmployeeDto dto)
        {
            var existing = await _repository.GetByIdAsync(dto.Id);
            if (existing is null) return;

            // Atualiza os campos usando métodos da entidade se necessário
            var updated = _mapper.Map(dto, existing);
            await _repository.UpdateAsync(updated);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
