using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class CITIES
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Zip_Code { get; set; }
        public string Country { get; set; }
        public DateTime Created_At { get; set; }
        public override string ToString()
        {
            return $"{Id}|{Name}|{Zip_Code}|{Country}|{Created_At}";
        }

    }
   

}
