using Pizzaria.Domain.Enums;
using Pizzaria.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzaria.Domain.Entities
{
    public class Order
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public OrderStatus Status { get; set; }
        public Customer? Customer { get; set; }
        public Employee? Attendant { get; set; }
        public ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();
        public decimal TotalAmount { get; set; }
        public string? Notes { get; set; }
        public DeliveryType DeliveryType { get; set; }
        public DeliveryAddress? DeliveryAddress { get; set; }
    }
}
