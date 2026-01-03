using Pizzaria.Shared.DTOs.DeliveryAddress;
using Pizzaria.Shared.Enums;

namespace Pizzaria.Shared.DTOs.Order
{
    public class CreateOrderDto
    {
        public Guid CustomerId { get; set; } = Guid.CreateVersion7();
        public List<CreateOrderItemDto> Items { get; set; } = new();
        public string Notes { get; set; } = string.Empty;
        public DeliveryTypeDto DeliveryType { get; set; }
        public DeliveryAddressDto? DeliveryAddress { get; set; }
    }

    public class CreateOrderItemDto
    {
        public Guid MenuItemId { get; set; } = Guid.CreateVersion7();
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public string Notes { get; set; } = string.Empty;
    }

}