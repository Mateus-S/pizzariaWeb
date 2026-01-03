using AutoMapper;
using Pizzaria.Domain.Entities;
using Pizzaria.Domain.Enums;
using Pizzaria.Shared.DTOs.Order;

namespace Pizzaria.Application.Mappings
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            // Leitura
            CreateMap<Order, OrderDto>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()))
                .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.Customer != null ? src.Customer.FullName : string.Empty))
                .ForMember(dest => dest.AttendantName, opt => opt.MapFrom(src => src.Attendant != null ? src.Attendant.FullName : string.Empty))
                .ForMember(dest => dest.DeliveryType, opt => opt.MapFrom(src => src.DeliveryType.ToString()))
                .ForMember(dest => dest.DeliveryAddress, opt => opt.MapFrom(src => src.DeliveryAddress))
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items));

            CreateMap<OrderItem, OrderItemDto>()
                .ForMember(dest => dest.MenuItemName, opt => opt.MapFrom(src => src.MenuItem != null ? src.MenuItem.Name : string.Empty));

            // Criação do item
            CreateMap<CreateOrderItemDto, OrderItem>()
                .ConstructUsing(dto => new OrderItem(dto.MenuItemId, dto.Quantity, dto.UnitPrice, dto.Notes));

            // Criação do pedido (sem AttendantId, que vem do contexto)
            CreateMap<CreateOrderDto, Order>()
                .ConstructUsing(dto => new Order(
                    dto.CustomerId,
                    null,
                    (DeliveryType)dto.DeliveryType,// AttendantId será injetado manualmente pelo contexto (ex: serviço)
                    dto.DeliveryAddress != null
                        ? new DeliveryAddress(
                            dto.DeliveryAddress.Street,
                            dto.DeliveryAddress.Number,
                            dto.DeliveryAddress.Neighborhood,
                            dto.DeliveryAddress.City,
                            dto.DeliveryAddress.Reference
                          )
                        : null,
                    string.IsNullOrWhiteSpace(dto.Notes) ? null : dto.Notes
                ));
        }
    }
}
