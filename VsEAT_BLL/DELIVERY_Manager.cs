using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace DTO
{
    public class DELIVERY_Manager : I_DELIVERY_Manager
    {
        public I_DELIVERY_DB DELIVERY_DB { get; }
        public IConfiguration Configuration { get ; set ; }

        public DELIVERY_Manager(IConfiguration configuration)
        {
            DELIVERY_DB = new DELIVERY_DB(configuration);
            Configuration = configuration;
        }

        public int createNewDelivery()
        {
            return DELIVERY_DB.AddDELIVERY();
        }

        public DELIVERY updateDeliveryTime(int deliveryNumber, int deliveryTimeId)
        {
            DELIVERY delivery = DELIVERY_DB.GetDELIVERY(deliveryNumber);

            delivery.Fk_Id_Delivery_Time = deliveryTimeId;

            return DELIVERY_DB.UpdateDELIVERY_Fk_Id_Delivery_Time(delivery);
        }

        public DELIVERY updateServiceClass(int deliveryNumber, int serviceClassId)
        {
            DELIVERY delivery = DELIVERY_DB.GetDELIVERY(deliveryNumber);

            delivery.Fk_Id_Service_Class = serviceClassId;

            return DELIVERY_DB.UpdateDELIVERY_Fk_Id_Service_Class(delivery);
        }

        public DELIVERY assignCourier(int deliveryNumber, int restaurantNumber)
        {
            DELIVERY_COURIER_Manager dcm = new DELIVERY_COURIER_Manager(Configuration);
            
            DELIVERY delivery = DELIVERY_DB.GetDELIVERY(deliveryNumber);
            DELIVERY_DB.UpdateDELIVERY_Start_Time(delivery);
            delivery.Fk_Id_Delivery_Courier = dcm.getAvailableCourier(restaurantNumber, deliveryNumber);
            
            return DELIVERY_DB.UpdateDELIVERY_Fk_Id_Delivery_Courier(delivery);
        }

        public List<DELIVERY> displayDelivery(int courierNumber)
        {
            return DELIVERY_DB.GetDELIVERYforCourier(courierNumber);
        }

        public DELIVERY archiveDelivery(int deliveryNumber)
        {
            DELIVERY delivery = DELIVERY_DB.GetDELIVERY(deliveryNumber);
            DELIVERY_DB.UpdateDELIVERY_Finish_Time(delivery);

            delivery.Fk_Id_Delivery_Status = 15;
            ORDERS_DB om = new ORDERS_DB(Configuration);
            ORDERS orders = om.GetORDERS(DELIVERY_DB.GetORDERSid(deliveryNumber));
            orders.Fk_Id_Order_Status = 7;

            om.UpdateORDERS_Fk_Id_Order_Status(orders);

            return DELIVERY_DB.UpdateDELIVERY_Fk_Id_Delivery_Status(delivery);
        }
    }
}
