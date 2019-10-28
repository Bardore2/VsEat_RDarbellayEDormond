using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public interface I_BILLS_DB
    {
        IConfiguration Config { get; }

        BILLS AddBILLS(BILLS bills);
        BILLS GetBILLS(int Id);
        BILLS UpdateBILLS_Payment_Date(BILLS bills);
    }
   

}
