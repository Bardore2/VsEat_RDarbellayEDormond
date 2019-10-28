using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace DTO
{
    public class BILLS_Manager : I_BILLS_Manager
    {
        public I_BILLS_DB BILLS_DB { get; }

        public IConfiguration Configuration { get; set; }

        public BILLS_Manager(IConfiguration configuration)
        {
            BILLS_DB = new BILLS_DB(configuration);
            Configuration = configuration;
        }

        public int createNewBills(int orderNumber)
        {
            ORDERS_DISHES_DB odm = new ORDERS_DISHES_DB(Configuration);
            ORDERS_DB om = new ORDERS_DB(Configuration);

            SERVICE_CLASS_DB scm = new SERVICE_CLASS_DB(Configuration);
            DELIVERY_DB dm = new DELIVERY_DB(Configuration);

            ORDERS orders = om.GetORDERS(orderNumber);

            BILLS bills = new BILLS();
            bills.Amount = odm.GetAmount(orders) + scm.GetAmount(dm.GetDELIVERY(orders.Fk_Id_Delivery));
            bills = BILLS_DB.AddBILLS(bills);
            return bills.Id;
        }

        public BILLS displayBills(int orderNumber)
        {
            ORDERS_DB om = new ORDERS_DB(Configuration);
            return BILLS_DB.GetBILLS(om.GetORDERS(orderNumber).Fk_Id_Bills);
        }
    }


}
