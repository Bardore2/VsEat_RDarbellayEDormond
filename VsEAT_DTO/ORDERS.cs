using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class ORDERS
    {
        public int Id { get; set; }
        public DateTime Created_At { get; set; }
        public int Fk_Id_Bills { get; set; }
        public int Fk_Id_Delivery { get; set; }
        public int Fk_Id_Customers { get; set; }
        public int Fk_Id_Order_Status { get; set; }

        public override string ToString()
        {
            return $"{Id}|{Created_At}|{Fk_Id_Bills}|{Fk_Id_Delivery}|{Fk_Id_Customers}|{Fk_Id_Order_Status}";
        }
    }
}
