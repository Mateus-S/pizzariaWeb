namespace Pizzaria.Application.Dtos.Order
{
    public class UpdateOrderDto
    {
        public Guid Id { get; set; }
        public string Status { get; set; } = null!;
    }
}