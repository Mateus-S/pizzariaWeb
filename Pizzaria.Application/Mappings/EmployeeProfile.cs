using AutoMapper;
using Pizzaria.Domain.Entities;
using Pizzaria.Shared.DTOs.Employee;

namespace Pizzaria.Application.Mappings
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeDto>();
            CreateMap<CreateEmployeeDto, Employee>();
            CreateMap<UpdateEmployeeDto, Employee>();
        }
    }

}