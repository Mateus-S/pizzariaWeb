using AutoMapper;
using Pizzaria.Domain.Entities;
using Pizzaria.Application.Dtos.Employee;

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