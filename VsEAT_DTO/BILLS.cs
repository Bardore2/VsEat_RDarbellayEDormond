using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class BILLS
    {
        public int Id { get; set; }
        public DateTime Billing_Date { get; set; }
        public DateTime Payment_Date { get; set; }
        public double Amount { get; set; }
        public DateTime Created_At { get; set; }

        public override string ToString()
        {
            return $"{Id}|{Billing_Date}|{Payment_Date}|{Amount} CHF|{Created_At}";
        }
    }
   

}
