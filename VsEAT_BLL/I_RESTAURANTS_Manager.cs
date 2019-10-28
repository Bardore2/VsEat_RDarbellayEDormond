using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public interface I_RESTAURANTS_Manager
    {
        I_RESTAURANTS_DB RESTAURANTS_DB { get; }

        List<RESTAURANTS> displayRestaurants();
    }
}
