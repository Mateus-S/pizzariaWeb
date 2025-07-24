using AutoMapper;
using Pizzaria.Domain.Entities;
using Pizzaria.Application.Dtos.Employee;

namespace Pizzaria.Application.Mappings
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeDto>().ReverseMap();
            CreateMap<Employee, CreateEmployeeDto>().ReverseMap();
        }
    }
}