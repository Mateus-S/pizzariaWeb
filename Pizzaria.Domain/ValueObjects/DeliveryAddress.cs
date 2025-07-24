using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzaria.Domain.ValueObjects
{
    public class DeliveryAddress
    {
        public string Street { get; set; } = null!;
        public string Number { get; set; } = null!;
        public string Neighborhood { get; set; } = null!;
        public string City { get; set; } = null!;
        public string Reference { get; set; } = null!;
    }

}
