using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public interface I_DELIVERY_TIME_DB
    {
        IConfiguration Config { get; }

        List<DELIVERY_TIME> GetDELIVERY_TIME();

        int GetMaximumDeliveryTimeId();


    }
}
