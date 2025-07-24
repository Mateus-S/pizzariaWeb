using Pizzaria.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzaria.Domain.Entities
{
    public class Employee
    {
        public Guid Id { get; set; }
        public string FullName { get; set; } = null!;
        public EmployeeRole Role { get; set; }
        public string DocumentNumber { get; set; } = null!;
        public bool IsActive { get; set; } = true;
    }

}
