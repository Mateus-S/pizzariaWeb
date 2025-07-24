namespace Pizzaria.Application.Dtos.Customer
{
    public class CreateCustomerDto
    {
        public string FullName { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string? Notes { get; set; }
    }
}