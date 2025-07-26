namespace Pizzaria.Application.Dtos.Employee
{
    public class CreateEmployeeDto
    {
        public string FullName { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public string DocumentNumber { get; set; } = string.Empty;
    }

}