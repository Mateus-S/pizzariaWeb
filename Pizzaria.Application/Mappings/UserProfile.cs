using AutoMapper;
using Pizzaria.Domain.Entities;
using Pizzaria.Shared.DTOs.User;
using Pizzaria.Shared.Enums;

namespace Pizzaria.Application.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            // Entidade → Leitura
            CreateMap<User, UserDto>()
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role.ToString()));

            // Criação → Entidade (service vai hash a senha)
            CreateMap<CreateUserDto, User>()
                .ConstructUsing(dto => new User(
                    dto.Name,
                    dto.Email,
                    "", // password hash será definido manualmente no service
                    (Domain.Enums.UserRole)dto.Role));

            // Atualização → Entidade
            CreateMap<UpdateUserDto, User>()
                .ForMember(dest => dest.Id, opt => opt.Ignore()) // geralmente você busca a entidade antes
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive));
        }
    }
}
