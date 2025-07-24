using AutoMapper;
using Pizzaria.Domain.Entities;
using Pizzaria.Application.Dtos.Customer;

namespace Pizzaria.Application.Mappings
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<Customer, CreateCustomerDto>().ReverseMap();
        }
    }
}