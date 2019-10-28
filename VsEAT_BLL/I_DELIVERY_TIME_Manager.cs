using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public interface I_DELIVERY_TIME_Manager
    {
        I_DELIVERY_TIME_DB DELIVERY_TIME_DB { get; }

        List<DELIVERY_TIME> displayDeliveryTime();
    }
}
