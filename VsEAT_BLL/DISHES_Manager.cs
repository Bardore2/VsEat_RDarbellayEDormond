using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace DTO
{
    public class DISHES_Manager : I_DISHES_Manager
    {
        public I_DISHES_DB DISHES_DB { get; }

        public DISHES_Manager(IConfiguration configuration)
        {
            DISHES_DB = new DISHES_DB(configuration);

        }

        public List<DISHES> displayDishesForRestaurant(int restaurantNumber)
        {
            return DISHES_DB.GetDISHES(restaurantNumber);
        }
    }
}
