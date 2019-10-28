using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public interface I_DELIVERY_COURIER_Manager
    {
        I_DELIVERY_COURIER_DB DELIVERY_COURIER_DB { get; }

        int getAvailableCourier(int restaurantNumber, int deliveryNumber);

        int checkCourierLogin(string [] stab);
    }
}
