using AutoMapper;
using Pizzaria.Domain.Entities;
using Pizzaria.Application.Dtos.Product;

namespace Pizzaria.Application.Mappings
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();
        }
    }
}