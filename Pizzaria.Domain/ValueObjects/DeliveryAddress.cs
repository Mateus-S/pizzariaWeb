public class DeliveryAddress
{
    public string Street { get; private set; }
    public string Number { get; private set; }
    public string Neighborhood { get; private set; }
    public string City { get; private set; }
    public string Reference { get; private set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    private DeliveryAddress() { } // EF Core
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

    public DeliveryAddress(string street, string number, string neighborhood, string city, string reference)
    {
        Street = street;
        Number = number;
        Neighborhood = neighborhood;
        City = city;
        Reference = reference;
    }

    // Comparação estrutural (VO)
    public override bool Equals(object? obj)
    {
        if (obj is not DeliveryAddress other) return false;
        return Street == other.Street &&
               Number == other.Number &&
               Neighborhood == other.Neighborhood &&
               City == other.City &&
               Reference == other.Reference;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Street, Number, Neighborhood, City, Reference);
    }
}
