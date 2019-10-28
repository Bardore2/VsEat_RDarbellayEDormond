using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public interface I_DELIVERY_DB
    {
        IConfiguration Config { get; }

        int AddDELIVERY();
        DELIVERY GetDELIVERY(int Id);
        List<DELIVERY> GetDELIVERYforCourier(int deliveryCourierNumber);
        DELIVERY UpdateDELIVERY_Start_Time(DELIVERY delivery);
        DELIVERY UpdateDELIVERY_Finish_Time(DELIVERY delivery);
        DELIVERY UpdateDELIVERY_Fk_Id_Service_Class(DELIVERY delivery);
        DELIVERY UpdateDELIVERY_Fk_Id_Delivery_Status(DELIVERY delivery);
        DELIVERY UpdateDELIVERY_Fk_Id_Delivery_Time(DELIVERY delivery);
        DELIVERY UpdateDELIVERY_Fk_Id_Delivery_Courier(DELIVERY delivery);

        int GetORDERSid(int deliveryNumber); 
    }
}
