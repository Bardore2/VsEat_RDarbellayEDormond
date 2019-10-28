using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public interface I_SERVICE_CLASS_DB
    {
        IConfiguration Config { get; }

        List<SERVICE_CLASS> GetSERVICE_CLASS();
        double GetAmount(DELIVERY delivery);

    }
}
