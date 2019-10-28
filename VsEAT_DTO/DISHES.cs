using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class DISHES
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }
        public double Price { get; set; }
        public int Status { get; set; }
        public DateTime Created_At { get; set; }
        public int Fk_Id_Restaurants { get; set; }

        public override string ToString()
        {
            return $"{Id}|{Name}|{Price} CHF|{Status}|{Created_At}|{Fk_Id_Restaurants}";
        }
    }
}
