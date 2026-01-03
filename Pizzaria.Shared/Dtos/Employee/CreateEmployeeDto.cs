using Pizzaria.Shared.Enums;

namespace Pizzaria.Shared.DTOs.Employee
{
    public class CreateEmployeeDto
    {
        public string FullName { get; set; } = string.Empty;
        public  EmployeeRoleDto Role { get; set; }
        public string DocumentNumber { get; set; } = string.Empty;
    }

}