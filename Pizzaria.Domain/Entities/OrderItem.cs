using Pizzaria.Domain.Entities;

public class OrderItem
{
    public Guid Id { get; private set; }

    public Guid MenuItemId { get; private set; }
    public MenuItem MenuItem { get; private set; } = null!;

    public Guid OrderId { get; private set; }
    public Order Order { get; private set; } = null!;

    public int Quantity { get; private set; }
    public decimal UnitPrice { get; private set; }
    public string? Notes { get; private set; }

    public decimal Total => Quantity * UnitPrice;

    private OrderItem() { }

    public OrderItem(Guid menuItemId, int quantity, decimal unitPrice, string? notes)
    {
        if (quantity <= 0)
            throw new ArgumentOutOfRangeException(nameof(quantity), "A quantidade deve ser maior que zero.");

        if (unitPrice < 0)
            throw new ArgumentOutOfRangeException(nameof(unitPrice), "O preço unitário não pode ser negativo.");

        Id = Guid.NewGuid();
        MenuItemId = menuItemId;
        Quantity = quantity;
        UnitPrice = unitPrice;
        Notes = notes;
    }
}
