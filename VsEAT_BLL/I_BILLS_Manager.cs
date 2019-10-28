using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public interface I_BILLS_Manager
    {
        I_BILLS_DB BILLS_DB { get; }
        IConfiguration Configuration { get; set; }

        int createNewBills(int orderNumber);

        BILLS displayBills(int orderNumber);
    }
   

}
