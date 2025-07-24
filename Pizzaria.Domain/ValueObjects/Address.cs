using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzaria.Domain.ValueObjects
{
    public class Address
    {
        public string Street { get; set; } = null!;
        public string Number { get; set; } = null!;
        public string Neighborhood { get; set; } = null!;
        public string City { get; set; } = null!;
        public string State { get; set; } = null!;
        public string ZipCode { get; set; } = null!;
        public string? Complement { get; set; }
    }

}
