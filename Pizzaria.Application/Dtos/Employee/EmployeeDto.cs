namespace Pizzaria.Application.Dtos.Employee
{
    public class EmployeeDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; } = null!;
        public string Role { get; set; } = null!;
        public string DocumentNumber { get; set; } = null!;
        public bool IsActive { get; set; }
    }
}