using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzaria.Shared.Enums
{
    public enum OrderStatusDto
    {
        Received,
        InPreparation,
        Ready,
        OutForDelivery,
        Delivered,
        Cancelled
    }

}
