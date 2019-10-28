using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class ORDERS_DISHES
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public DateTime Created_At { get; set; }
        public int Fk_Id_Dishes { get; set; }
        public int Fk_Id_Orders { get; set; }

        public override string ToString()
        {
            return $"{Id}|{Quantity}|{Created_At}|{Fk_Id_Dishes}|{Fk_Id_Orders}";
        }
    }
}
