using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace DTO
{
    public class SERVICE_CLASS_Manager : I_SERVICE_CLASS_Manager
    {
        public I_SERVICE_CLASS_DB SERVICE_CLASS_DB { get; }

        public SERVICE_CLASS_Manager(IConfiguration configuration)
        {
            SERVICE_CLASS_DB = new SERVICE_CLASS_DB(configuration);

        }

        public List<SERVICE_CLASS> displayServiceClass()
        {
            return SERVICE_CLASS_DB.GetSERVICE_CLASS();
        }
    }
}
