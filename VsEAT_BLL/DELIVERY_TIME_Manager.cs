using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace DTO
{
    public class DELIVERY_TIME_Manager : I_DELIVERY_TIME_Manager
    {
        public I_DELIVERY_TIME_DB DELIVERY_TIME_DB { get; }

        public DELIVERY_TIME_Manager(IConfiguration configuration)
        {
            DELIVERY_TIME_DB = new DELIVERY_TIME_DB(configuration);

        }

        public List<DELIVERY_TIME> displayDeliveryTime()
        {
            return DELIVERY_TIME_DB.GetDELIVERY_TIME();
        }
    }
}
