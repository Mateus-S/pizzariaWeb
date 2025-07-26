namespace Pizzaria.Domain.Entities
{
    public class Customer
    {
        public Guid Id { get; private set; }
        public string FullName { get; private set; } = null!;
        public string PhoneNumber { get; private set; } = null!;
        public string? Notes { get; private set; }

        // Lista de endereços (Value Object)
        public ICollection<Address> Addresses { get; private set; } = new List<Address>();

        private Customer() { }

        public Customer(string fullName, string phoneNumber, string? notes = null)
        {
            if (string.IsNullOrWhiteSpace(fullName))
                throw new ArgumentException("Nome completo é obrigatório.", nameof(fullName));

            if (string.IsNullOrWhiteSpace(phoneNumber))
                throw new ArgumentException("Número de telefone é obrigatório.", nameof(phoneNumber));

            Id = Guid.NewGuid();
            FullName = fullName;
            PhoneNumber = phoneNumber;
            Notes = notes;
        }

        public void AddAddress(Address address)
        {
            if (address == null) throw new ArgumentNullException(nameof(address));
            Addresses.Add(address);
        }
    }
}
