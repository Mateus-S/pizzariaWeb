using Pizzaria.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzaria.Domain.Entities
{
    // Domain/Entities/MenuItem.cs
    public class MenuItem
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;
        public decimal Price { get; private set; }
        public bool IsActive { get; private set; } = true;

        // 🔄 Nova relação
        public Guid CategoryId { get; private set; }
        public Category Category { get; private set; } = null!;

        private MenuItem() { }

        public MenuItem(string name, string description, decimal price, Guid categoryId)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            Price = price;
            CategoryId = categoryId;
        }

        public void Deactivate() => IsActive = false;
        public void Activate() => IsActive = true;
    }

}
