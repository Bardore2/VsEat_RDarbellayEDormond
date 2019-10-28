using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public interface I_CUSTOMERS_Manager
    {
        I_CUSTOMERS_DB CUSTOMERS_DB { get; }
        IConfiguration Configuration { get; set; }

        int createNewCustomer(string[] stab);

        int checkCustomerLogin(string[] stab);
    }
    
}
