using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public interface I_CITIES_Manager
    {
        I_CITIES_DB CITIES_DB { get; }

        int getCitiesId(string [] stab);
        int createNewCities(string[] stab);

    }
   

}
