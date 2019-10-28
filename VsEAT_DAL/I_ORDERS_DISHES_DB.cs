using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public interface I_ORDERS_DISHES_DB
    {
        IConfiguration Config { get; }

        ORDERS_DISHES AddORDERS_DISHES(ORDERS_DISHES orders_dishes);
        double GetAmount(ORDERS orders);
    }
}
