﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetMentor.PageMonitor.Application.Exceptions
{
    public class UnauthorizedException : Exception
    {
        public UnauthorizedException() : base ("Unauthorized") 
        { 
        }
    }
}
