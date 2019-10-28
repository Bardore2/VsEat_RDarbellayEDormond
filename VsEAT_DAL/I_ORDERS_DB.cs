using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public interface I_ORDERS_DB
    {
        IConfiguration Config { get; }

        int AddORDERS(int customerNumber);
        ORDERS GetORDERS(int Id);
        ORDERS GetORDERS(string [] stab);
        List<ORDERS> GetORDERSForCustomer(int customerNumber);
        ORDERS UpdateORDERS_Fk_Id_Delivery(ORDERS orders);
        ORDERS UpdateORDERS_Fk_Id_Bills(ORDERS orders);
        ORDERS UpdateORDERS_Fk_Id_Order_Status(ORDERS orders);
    }
}
