using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace DTO
{
    public class STATUS_Manager : I_STATUS_Manager
    {
        public I_STATUS_DB STATUS_DB { get; }

        public STATUS_Manager(IConfiguration configuration)
        {
            STATUS_DB = new STATUS_DB(configuration);

        }

        public STATUS displayStatus(int statusId)
        {
            return STATUS_DB.GetSTATUS(statusId);
        }
    }
}
