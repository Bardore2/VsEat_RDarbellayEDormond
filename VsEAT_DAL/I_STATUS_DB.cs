using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public interface I_STATUS_DB
    {
        IConfiguration Config { get; }

        STATUS GetSTATUS(int Id);
    }
}
