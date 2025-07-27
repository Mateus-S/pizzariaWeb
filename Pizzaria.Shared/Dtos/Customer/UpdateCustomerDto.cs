using Pizzaria.Shared.DTOs.MenuItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzaria.Shared.DTOs.Customer
{
    public class UpdateCustomerDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string? Notes { get; set; }
        public List<AddressDto> Addresses { get; set; } = new();
    }

}
