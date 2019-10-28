using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public interface I_ORDERS_DISHES_Manager
    {
        I_ORDERS_DISHES_DB ORDERS_DISHES_DB { get; }

        int createNewOrdersDishes(string [] stab, int orderNumber);
    }
}
