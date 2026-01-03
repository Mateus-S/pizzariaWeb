namespace Pizzaria.Shared.DTOs.Employee
{
    public class EmployeeDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public string DocumentNumber { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }

}