using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace DTO
{
    public class DELIVERY_COURIER_Manager : I_DELIVERY_COURIER_Manager
    {
        public I_DELIVERY_COURIER_DB DELIVERY_COURIER_DB { get; }

        public DELIVERY_COURIER_Manager(IConfiguration configuration)
        {
            DELIVERY_COURIER_DB = new DELIVERY_COURIER_DB(configuration);

        }

        public int getAvailableCourier(int restaurantNumber, int deliveryNumber)
        {
           DELIVERY_COURIER delivery_courier = DELIVERY_COURIER_DB.GetFreeDELIVERY_COURIER(restaurantNumber, deliveryNumber);
            return delivery_courier.Id;
        }

        public int checkCourierLogin(string [] stab)
        {
            DELIVERY_COURIER delivery_courier = DELIVERY_COURIER_DB.GetDELIVERY_COURIER(stab[0]);

            if (stab[1].Equals(delivery_courier.Password))
                return delivery_courier.Id;

            return 0;
        }
    }
}
