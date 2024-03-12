﻿using DotNetMentor.PageMonitor.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetMentor.PageMonitor.Domain.Entities
{
    public class User : DomainEntity
    {
        public required string Email { get; set; }
        public required string HashedPassword { get; set; }
        public DateTimeOffset RegisterDate { get; set; }
    }
}
