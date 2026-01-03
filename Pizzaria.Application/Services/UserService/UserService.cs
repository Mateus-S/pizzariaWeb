using AutoMapper;
using Pizzaria.Application.Interfaces.Services.UserService;
using Pizzaria.Domain.Entities;
using Pizzaria.Domain.Interfaces.Repositories.UserRepository;
using Pizzaria.Shared.DTOs.User;

namespace Pizzaria.Application.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserDto>> GetAllAsync()
        {
            var users = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<UserDto>>(users);
        }

        public async Task<UserDto?> GetByIdAsync(Guid id)
        {
            var user = await _repository.GetByIdAsync(id);
            return user is null ? null : _mapper.Map<UserDto>(user);
        }

        public async Task AddAsync(CreateUserDto dto)
        {
            // Aqui você pode incluir o hash da senha antes de criar o User
            var user = new User(
                dto.Name,
                dto.Email,
                HashPassword(dto.Password), // método fictício para hashing
                (Domain.Enums.UserRole)dto.Role
            );

            await _repository.AddAsync(user);
        }

        public async Task UpdateAsync(UpdateUserDto dto)
        {
            var user = await _repository.GetByIdAsync(dto.Id);
            if (user is null) throw new Exception("Usuário não encontrado.");

            if (dto.IsActive)
                user.Activate();
            else
                user.Deactivate();

            var updatedUser = new User(
                user.Name, user.Email, user.PasswordHash, (Domain.Enums.UserRole)dto.Role
            );

            await _repository.UpdateAsync(user);
        }

        public async Task DeleteAsync(Guid id)
        {
            var user = await _repository.GetByIdAsync(id);
            if (user is null) throw new Exception("Usuário não encontrado.");
            await _repository.DeleteAsync(user);
        }

        private string HashPassword(string password)
        {
            // Aqui você pode usar BCrypt ou outro algoritmo
            return $"HASHED({password})"; // apenas placeholder
        }
    }
}
