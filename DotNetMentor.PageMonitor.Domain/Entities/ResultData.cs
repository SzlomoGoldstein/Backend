using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetMentor.PageMonitor.Domain.Entities
{
    public class ResultData
    {
        public required int StatusCode { get; set; }

        public required string Content { get; set; }

        public required TimeSpan ResponseTime { get; set; }
    }
}
