public class Address
{
    public string Street { get; private set; }
    public string Number { get; private set; }
    public string Neighborhood { get; private set; }
    public string City { get; private set; }
    public string State { get; private set; }
    public string ZipCode { get; private set; }
    public string? Complement { get; private set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    private Address() { } // EF Core
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

    public Address(string street, string number, string neighborhood, string city, string state, string zipCode, string? complement = null)
    {
        Street = street;
        Number = number;
        Neighborhood = neighborhood;
        City = city;
        State = state;
        ZipCode = zipCode;
        Complement = complement;
    }

    public override bool Equals(object? obj)
    {
        if (obj is not Address other) return false;

        return Street == other.Street &&
               Number == other.Number &&
               Neighborhood == other.Neighborhood &&
               City == other.City &&
               State == other.State &&
               ZipCode == other.ZipCode &&
               Complement == other.Complement;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Street, Number, Neighborhood, City, State, ZipCode, Complement);
    }
}
