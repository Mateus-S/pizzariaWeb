using Pizzaria.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzaria.Domain.Interfaces.Repositories.MenuRepository
{
    public interface IMenuItemRepository
    {
        Task<List<MenuItem>> GetAllAsync();
        Task<MenuItem?> GetByIdAsync(Guid id);
        Task<MenuItem> AddAsync(MenuItem entity);
        Task UpdateAsync(MenuItem entity);
        Task DeleteAsync(MenuItem entity);
    }
}
