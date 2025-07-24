using AutoMapper;
using Pizzaria.Domain.Entities;
using Pizzaria.Application.Dtos.User;

namespace Pizzaria.Application.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, CreateUserDto>().ReverseMap();
        }
    }
}