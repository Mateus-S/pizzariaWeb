using AutoMapper;
using Pizzaria.Domain.Entities;
using Pizzaria.Shared.DTOs.User;

namespace Pizzaria.Application.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<CreateUserDto, User>()
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore()); // hashing feito no service

            CreateMap<UpdateUserDto, User>();
        }
    }

}