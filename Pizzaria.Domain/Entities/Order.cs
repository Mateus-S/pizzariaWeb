using Pizzaria.Domain.Entities;
using Pizzaria.Domain.Enums;
public class Order
{
    public Guid Id { get; private set; } = Guid.CreateVersion7();
    public DateTime CreatedAt { get; private set; }
    public OrderStatus Status { get; private set; }

    public Guid? CustomerId { get; private set; }
    public Customer? Customer { get; private set; }

    public Guid? AttendantId { get; private set; }
    public Employee? Attendant { get; private set; }

    public ICollection<OrderItem> Items { get; private set; }

    public decimal TotalAmount { get; private set; }

    public string? Notes { get; private set; }

    public DeliveryType DeliveryType { get; private set; }

    public DeliveryAddress? DeliveryAddress { get; private set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    private Order() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

    public Order(Guid? customerId, Guid? attendantId, DeliveryType deliveryType, DeliveryAddress? deliveryAddress, string? notes)
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.UtcNow;
        Status = OrderStatus.InPreparation;
        CustomerId = customerId;
        AttendantId = attendantId;
        DeliveryType = deliveryType;
        DeliveryAddress = deliveryAddress;
        Notes = notes;
        Items = new List<OrderItem>();
    }

    public void AddItem(OrderItem item)
    {
        if (item == null) throw new ArgumentNullException(nameof(item));
        Items.Add(item);
        TotalAmount = Items.Sum(i => i.Total);
    }

    public void UpdateStatus(OrderStatus status)
    {
        Status = status;
    }
}
