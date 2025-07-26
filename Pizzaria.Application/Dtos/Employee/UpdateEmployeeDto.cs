using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzaria.Application.Dtos.Employee
{
    public class UpdateEmployeeDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public string DocumentNumber { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }

}
