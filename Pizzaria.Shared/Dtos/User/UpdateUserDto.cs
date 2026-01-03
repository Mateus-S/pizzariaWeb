using Pizzaria.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzaria.Shared.DTOs.User
{
    public class UpdateUserDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public UserRoleDto Role { get; set; }
        public bool IsActive { get; set; }
    }

}
