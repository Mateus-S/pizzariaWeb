using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzaria.Domain.Entities
{
    // Domain/Entities/Category.cs
    public class Category
    {
        public Guid Id { get; set; } = Guid.CreateVersion7();
        public string Name { get;  set; } = string.Empty;
        public bool IsActive { get; set; } = true;

        // Navigation
        public ICollection<MenuItem> MenuItems { get; set; } = new List<MenuItem>();

        // EF Core needs a parameterless constructor
        private Category() { }

        public Category(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }

        public void Deactivate() => IsActive = false;
        public void Activate() => IsActive = true;
    }

}
