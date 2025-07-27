namespace Pizzaria.Shared.DTOs.Customer
{
    public class CustomerDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string? Notes { get; set; }
    }
}