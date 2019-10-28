using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public interface I_CUSTOMERS_DB
    {
        IConfiguration Config { get; }

        CUSTOMERS AddCUSTOMERS(CUSTOMERS customers);
        byte CheckExistingCUSTOMERS(string login);
        CUSTOMERS GetCUSTOMERS(string login);
        
    }
    
}
