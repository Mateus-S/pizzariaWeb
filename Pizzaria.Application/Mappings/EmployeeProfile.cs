using AutoMapper;
using Pizzaria.Domain.Entities;
using Pizzaria.Shared.DTOs.Employee;

namespace Pizzaria.Application.Mappings
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            // ✅ Leitura: entidade → DTO
            CreateMap<Employee, EmployeeDto>();

            // ✅ Criação: DTO → entidade usando o construtor
            CreateMap<CreateEmployeeDto, Employee>()
                .ConstructUsing(dto => new Employee(dto.FullName, (Domain.Enums.EmployeeRole)dto.Role, dto.DocumentNumber));

        }
    }

}