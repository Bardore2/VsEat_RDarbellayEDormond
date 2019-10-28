using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public interface I_ORDERS_Manager
    {
        I_ORDERS_DB ORDERS_DB { get; }
        IConfiguration Configuration { get; set; }

        int createNewOrders(int customerNumber);

        ORDERS addNewDelivery(int orderNumber);

        ORDERS addNewBills(int orderNumber);

        ORDERS confirmOrders(int orderNumber);

        ORDERS cancelOrders(int orderNumber);

        ORDERS cancelOrders(string [] stab);

        List<ORDERS> displayOrders(int customerNumber);


    }
}
