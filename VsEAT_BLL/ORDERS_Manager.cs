using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace DTO
{
    public class ORDERS_Manager : I_ORDERS_Manager
    {
        public I_ORDERS_DB ORDERS_DB { get; }
        public IConfiguration Configuration { get ; set ; }

        public ORDERS_Manager(IConfiguration configuration)
        {
            ORDERS_DB = new ORDERS_DB(configuration);
            Configuration = configuration;
        }

        public int createNewOrders(int customerNumber)
        {
            return ORDERS_DB.AddORDERS(customerNumber);

        }

        public ORDERS addNewDelivery(int orderNumber)
        {
            DELIVERY_Manager dem = new DELIVERY_Manager(Configuration);
            ORDERS orders = ORDERS_DB.GetORDERS(orderNumber);

            orders.Fk_Id_Delivery = dem.createNewDelivery();

            return ORDERS_DB.UpdateORDERS_Fk_Id_Delivery(orders);
        }

        public ORDERS addNewBills(int orderNumber)
        {
            BILLS_Manager bm = new BILLS_Manager(Configuration);
            ORDERS orders = ORDERS_DB.GetORDERS(orderNumber);
            orders.Fk_Id_Bills = bm.createNewBills(orderNumber);
            orders.Fk_Id_Order_Status = 2;

            DELIVERY_DB dm = new DELIVERY_DB(Configuration);
            DELIVERY delivery = dm.GetDELIVERY(orders.Fk_Id_Delivery);
            delivery.Fk_Id_Delivery_Status = 2;
            dm.UpdateDELIVERY_Fk_Id_Delivery_Status(delivery);
            ORDERS_DB.UpdateORDERS_Fk_Id_Bills(orders);
            return ORDERS_DB.UpdateORDERS_Fk_Id_Order_Status(orders);
        }

        public ORDERS confirmOrders(int orderNumber)
        {
            ORDERS orders = ORDERS_DB.GetORDERS(orderNumber);
            orders.Fk_Id_Order_Status = 4;

            BILLS_DB bm = new BILLS_DB(Configuration);
            BILLS bills = bm.GetBILLS(orders.Fk_Id_Bills);
            bm.UpdateBILLS_Payment_Date(bills);

            DELIVERY_DB dm = new DELIVERY_DB(Configuration);
            DELIVERY delivery = dm.GetDELIVERY(orders.Fk_Id_Delivery);
            delivery.Fk_Id_Delivery_Status = 4;
            dm.UpdateDELIVERY_Fk_Id_Delivery_Status(delivery);

            return ORDERS_DB.UpdateORDERS_Fk_Id_Order_Status(orders);
        }

        public ORDERS cancelOrders(int orderNumber)
        {
            ORDERS orders = ORDERS_DB.GetORDERS(orderNumber);
            orders.Fk_Id_Order_Status = 9;

            DELIVERY_DB dm = new DELIVERY_DB(Configuration);
            DELIVERY delivery = dm.GetDELIVERY(orders.Fk_Id_Delivery);
            delivery.Fk_Id_Delivery_Status = 9;
            dm.UpdateDELIVERY_Fk_Id_Delivery_Status(delivery);

            return ORDERS_DB.UpdateORDERS_Fk_Id_Order_Status(orders);
        }

        public ORDERS cancelOrders(string [] stab)
        {
            ORDERS orders = ORDERS_DB.GetORDERS(stab);
            orders.Fk_Id_Order_Status = 16;

            DELIVERY_DB dm = new DELIVERY_DB(Configuration);
            DELIVERY delivery = dm.GetDELIVERY(orders.Fk_Id_Delivery);
            delivery.Fk_Id_Delivery_Status = 16;
            dm.UpdateDELIVERY_Fk_Id_Delivery_Status(delivery);

            return ORDERS_DB.UpdateORDERS_Fk_Id_Order_Status(orders);
        }

        public List<ORDERS> displayOrders(int customerNumber)
        {
            return ORDERS_DB.GetORDERSForCustomer(customerNumber);
        }
    }
}
