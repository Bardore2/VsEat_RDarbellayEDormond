using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public interface I_DISHES_Manager
    {
        I_DISHES_DB DISHES_DB { get; }

        List<DISHES> displayDishesForRestaurant(int restaurantNumber);
    }
}
