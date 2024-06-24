using DotNetMentor.PageMonitor.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetMentor.PageMonitor.Domain.Entities
{
    public class Result : DomainEntity
    {
        public DateTimeOffset Date { get; set; } = DateTimeOffset.Now;

        public int MonitoredUrlId { get; set; }

        public MonitoredUrl Url { get; set; } = default!;

        public bool Success { get; set; } = false;
    }
}
