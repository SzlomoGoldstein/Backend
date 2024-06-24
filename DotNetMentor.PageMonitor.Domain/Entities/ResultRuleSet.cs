using DotNetMentor.PageMonitor.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetMentor.PageMonitor.Domain.Entities
{
    public class ResultRuleSet
    {
        public List<ResultRule> Rules { get; set; } = new List<ResultRule>();

        public ResultRuleSetOperatorEnum Operator { get; set; } = ResultRuleSetOperatorEnum.Or;
    }
}
