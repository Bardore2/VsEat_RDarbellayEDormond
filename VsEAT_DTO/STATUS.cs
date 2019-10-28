using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class STATUS
    {
        public int Id { get; set; }
        public string Designation { get; set; }
        public DateTime Created_At { get; set; }
        public override string ToString()
        {
            return $"{Id}|{Designation}|{Created_At}";
        }
    }
}
