namespace Pizzaria.Application.Dtos.Employee
{
    public class CreateEmployeeDto
    {
        public string FullName { get; set; } = null!;
        public string Role { get; set; } = null!;
        public string DocumentNumber { get; set; } = null!;
    }
}