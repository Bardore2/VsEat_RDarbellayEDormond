using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public interface I_CITIES_DB
    {
        IConfiguration Config { get; }

        List<CITIES> GetCITIES();

        int getCITIES(string[] stab);

        int addCITIES(string[] stab);

    }
   

}
