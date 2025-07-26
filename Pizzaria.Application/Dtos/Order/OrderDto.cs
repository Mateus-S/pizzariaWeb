using Pizzaria.Application.Dtos.DeliveryAddress;

namespace Pizzaria.Application.Dtos.Order
{
    public class OrderDto
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Status { get; set; } = string.Empty;
        public decimal TotalAmount { get; set; }

        public string? CustomerName { get; set; }
        public string? AttendantName { get; set; }

        public List<OrderItemDto> Items { get; set; } = new();
        public string DeliveryType { get; set; } = string.Empty;
        public DeliveryAddressDto? DeliveryAddress { get; set; }
    }


    public class OrderItemDto
    {
        public Guid Id { get; set; }
        public string MenuItemName { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public string? Notes { get; set; }
        public decimal Total => Quantity * UnitPrice;
    }

}