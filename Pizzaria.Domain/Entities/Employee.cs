using Pizzaria.Domain.Enums;

namespace Pizzaria.Domain.Entities
{
    public class Employee
    {
        public Guid Id { get; private set; }

        public string FullName { get; private set; } = null!;
        public EmployeeRole Role { get; private set; }

        public string DocumentNumber { get; private set; } = null!;
        public bool IsActive { get; private set; }
        public Guid? UserId { get; private set; }
        public User? User { get; private set; }

        private Employee() { }

        public Employee(string fullName, EmployeeRole role, string documentNumber)
        {
            if (string.IsNullOrWhiteSpace(fullName))
                throw new ArgumentException("Nome do funcionário é obrigatório.", nameof(fullName));

            if (string.IsNullOrWhiteSpace(documentNumber))
                throw new ArgumentException("Documento é obrigatório.", nameof(documentNumber));

            Id = Guid.NewGuid();
            FullName = fullName;
            Role = role;
            DocumentNumber = documentNumber;
            IsActive = true;
        }

        public void Deactivate() => IsActive = false;
        public void Activate() => IsActive = true;
    }
}
