﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetMentor.PageMonitor.Application.Interfaces
{
    public interface IAuthenticationDataProvider
    {
        int? GetUserId();
    }
}
