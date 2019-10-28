using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public interface I_DELIVERY_COURIER_DB
    {
        IConfiguration Config { get; }

        DELIVERY_COURIER GetDELIVERY_COURIER(string login);

        DELIVERY_COURIER GetFreeDELIVERY_COURIER(int restaurantsId, int delivery_time);
    }
}
