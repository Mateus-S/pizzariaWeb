using AutoMapper;
using Pizzaria.Domain.Entities;
using Pizzaria.Shared.DTOs.Customer;

namespace Pizzaria.Application.Mappings
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<Customer, UpdateCustomerDto>().ReverseMap();
            CreateMap<Customer, CreateCustomerDto>().ReverseMap();
        }
    }
}