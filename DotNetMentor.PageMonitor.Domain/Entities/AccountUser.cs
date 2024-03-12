﻿using DotNetMentor.PageMonitor.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetMentor.PageMonitor.Domain.Entities
{
    public class AccountUser : DomainEntity
    {
        public int AccountId { get; set; }
        public Account Account { get; set; } = default!;
        public string UserId { get; set; }
        public User User { get; set; } = default!;
    }
}