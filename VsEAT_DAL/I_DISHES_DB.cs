using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public interface I_DISHES_DB
    {
        IConfiguration Config { get; }

        List<DISHES> GetDISHES(int IdRestaurant);
    }
}
