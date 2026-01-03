using AutoMapper;
using Pizzaria.Domain.Entities;
using Pizzaria.Shared.DTOs.MenuItem;
using Pizzaria.Shared.DTOs.Product;

namespace Pizzaria.Application.Mappings
{
    public class MenuItemProfile : Profile
    {
        public MenuItemProfile()
        {
            // ✅ Leitura (MenuItem → DTO)
            CreateMap<MenuItem, MenuItemDto>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));

            // ✅ Criação (Create DTO → Entity via construtor)
            CreateMap<CreateMenuItemDto, MenuItem>()
                .ConstructUsing(dto => new MenuItem(dto.Name, dto.Description, dto.Price, dto.CategoryId));

        }
    }

}