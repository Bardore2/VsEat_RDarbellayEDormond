using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace DTO
{
    public class CITIES_Manager : I_CITIES_Manager
    {
        public I_CITIES_DB CITIES_DB { get; }

        public CITIES_Manager(IConfiguration configuration)
        {
            CITIES_DB = new CITIES_DB(configuration);

        }

        public int getCitiesId(string [] stab)
        {
            return CITIES_DB.getCITIES(stab);
        }

        public int createNewCities(string [] stab)
        {
            return CITIES_DB.addCITIES(stab);
        }
    }


}
