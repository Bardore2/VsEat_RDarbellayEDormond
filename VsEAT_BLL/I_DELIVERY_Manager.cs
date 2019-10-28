using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public interface I_DELIVERY_Manager
    {
        I_DELIVERY_DB DELIVERY_DB { get; }
        IConfiguration Configuration { get; set; }

        int createNewDelivery();

        DELIVERY updateDeliveryTime(int deliveryNumber, int deliveryTimeId);

        DELIVERY updateServiceClass(int deliveryNumber, int serviceClassId);

        DELIVERY assignCourier(int deliveryNumber, int restaurantNumber);

        List<DELIVERY> displayDelivery(int courierNumber);

        DELIVERY archiveDelivery(int deliveryNumber);
    }
}
