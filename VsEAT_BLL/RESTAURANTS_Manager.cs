using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace DTO
{
    public class RESTAURANTS_Manager : I_RESTAURANTS_Manager
    {
        public I_RESTAURANTS_DB RESTAURANTS_DB { get; }

        public RESTAURANTS_Manager(IConfiguration configuration)
        {
            RESTAURANTS_DB = new RESTAURANTS_DB(configuration);

        }

        public List<RESTAURANTS> displayRestaurants()
        {
            return RESTAURANTS_DB.GetRESTAURANTS();
        }
    }
}
