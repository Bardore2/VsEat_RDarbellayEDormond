using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class DELIVERY
    {
        public int Id { get; set; }
        public TimeSpan Start_Time { get; set; }
        public TimeSpan Finish_Time { get; set; }
        public DateTime Created_At { get; set; }
        public int Fk_Id_Service_Class { get; set; }
        public int Fk_Id_Delivery_Status { get; set; }
        public int Fk_Id_Delivery_Time { get; set; }
        public int Fk_Id_Delivery_Courier { get; set; }
        public override string ToString()
        {
            return $"{Id}|{Start_Time}|{Finish_Time}|{Created_At}|{Fk_Id_Service_Class}|{Fk_Id_Delivery_Status}|{Fk_Id_Delivery_Time}|{Fk_Id_Delivery_Courier}";
        }
    }
}
