using Pizzaria.Shared.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzaria.Application.Interfaces.Services.UserService
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAllAsync();
        Task<UserDto?> GetByIdAsync(Guid id);
        Task AddAsync(CreateUserDto dto);
        Task UpdateAsync(UpdateUserDto dto);
        Task DeleteAsync(Guid id);
    }
}
