using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public interface I_RESTAURANTS_DB
    {
        IConfiguration Config { get; }

        List<RESTAURANTS> GetRESTAURANTS();

        int GetCITIES(int Id);
    }
}
