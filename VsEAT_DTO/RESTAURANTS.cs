using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class RESTAURANTS
    {
        public int Id { get; set; }
        public string Merchant_Name { get; set; }
        public string Address { get; set; }
        public string Phone_Number { get; set; }
        public DateTime Created_At { get; set; }
        public int Fk_Id_Cities { get; set; }

        public override string ToString()
        {
            return $"{Id}|{Merchant_Name}|{Address}|{Phone_Number}|{Created_At}|{Fk_Id_Cities}";
        }
    }
}
