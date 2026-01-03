namespace Pizzaria.Shared.DTOs.Order
{
    public class UpdateOrderDto
    {
        public Guid Id { get; set; }
        public string Status { get; set; } = string.Empty;
        public List<UpdateOrderItemDto> Items { get; set; } = new();

    }
    public class UpdateOrderItemDto
    {
        public Guid Id { get; set; } // Id do item do pedido
        public int Quantity { get; set; }
        public decimal UnitPrice { get; private set; }
        public string? Notes { get; set; }

    }
}