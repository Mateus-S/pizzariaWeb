using AutoMapper;
using Pizzaria.Domain.Entities;
using Pizzaria.Shared.DTOs.Order;

namespace Pizzaria.Application.Mappings
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderDto>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items));
            CreateMap<OrderItem, OrderItemDto>().ReverseMap();

            CreateMap<CreateOrderDto, Order>();
            CreateMap<CreateOrderItemDto, OrderItem>();
        }
    }
}