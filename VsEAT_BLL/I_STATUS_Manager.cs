using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public interface I_STATUS_Manager
    {
        I_STATUS_DB STATUS_DB { get; }

        STATUS displayStatus(int StatusId);
    }
}
