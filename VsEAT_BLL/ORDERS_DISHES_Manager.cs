using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace DTO
{
    public class ORDERS_DISHES_Manager : I_ORDERS_DISHES_Manager
    {
        public I_ORDERS_DISHES_DB ORDERS_DISHES_DB { get; }

        public ORDERS_DISHES_Manager(IConfiguration configuration)
        {
            ORDERS_DISHES_DB = new ORDERS_DISHES_DB(configuration);

        }

        public int createNewOrdersDishes(string [] stab, int orderNumber)
        {
            ORDERS_DISHES orders_dishes = new ORDERS_DISHES();
            orders_dishes.Quantity = Convert.ToInt32(stab[1]);
            orders_dishes.Fk_Id_Dishes = Convert.ToInt32(stab[0]);
            orders_dishes.Fk_Id_Orders = orderNumber;

            ORDERS_DISHES_DB.AddORDERS_DISHES(orders_dishes);

            return orderNumber;
        }
    }
}
