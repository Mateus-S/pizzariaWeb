using Pizzaria.Domain.Enums;

namespace Pizzaria.Domain.Entities
{
    public class User
    {
        public Guid Id { get; private set; } = Guid.CreateVersion7();

        public string Name { get; private set; } = null!;
        public string Email { get; private set; } = null!;
        public string PasswordHash { get; private set; } = null!;
        public UserRole Role { get; private set; }
        public bool IsActive { get; private set; }

        private User() { }

        public User(string name, string email, string passwordHash, UserRole role)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Nome é obrigatório", nameof(name));

            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("E-mail é obrigatório", nameof(email));

            if (string.IsNullOrWhiteSpace(passwordHash))
                throw new ArgumentException("Senha é obrigatória", nameof(passwordHash));

            Id = Guid.NewGuid();
            Name = name;
            Email = email;
            PasswordHash = passwordHash;
            Role = role;
            IsActive = true;
        }

        public void Deactivate() => IsActive = false;
        public void Activate() => IsActive = true;

        public void ChangePassword(string newPasswordHash)
        {
            if (string.IsNullOrWhiteSpace(newPasswordHash))
                throw new ArgumentException("Nova senha inválida", nameof(newPasswordHash));

            PasswordHash = newPasswordHash;
        }
    }
}
