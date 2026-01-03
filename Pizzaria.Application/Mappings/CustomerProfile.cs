using AutoMapper;
using Pizzaria.Domain.Entities;
using Pizzaria.Shared.DTOs.Customer;

namespace Pizzaria.Application.Mappings
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            // ✅ Leitura: Entity → DTO
            CreateMap<Customer, CustomerDto>();

            // ✅ Criação: CreateCustomerDto → Customer usando o construtor
            CreateMap<CreateCustomerDto, Customer>()
                .ConstructUsing(dto => new Customer(dto.FullName, dto.PhoneNumber, dto.Notes));
        }
    }
}