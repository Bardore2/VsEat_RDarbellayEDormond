using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class DELIVERY_TIME
    {
        public int Id { get; set; }
        public string Time_Zone { get; set; }
        public DateTime Created_At { get; set; }

        public override string ToString()
        {
            return $"{Id}|{Time_Zone}|{Created_At}";
        }
    }
}
