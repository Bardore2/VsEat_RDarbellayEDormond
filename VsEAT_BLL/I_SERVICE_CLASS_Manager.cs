﻿using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public interface I_SERVICE_CLASS_Manager
    {
        I_SERVICE_CLASS_DB SERVICE_CLASS_DB { get; }

        List<SERVICE_CLASS> displayServiceClass();
    }
}
