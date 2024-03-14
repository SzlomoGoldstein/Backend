using DotNetMentor.PageMonitor.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetMentor.PageMonitor.Application.Logic.Abstractions
{
    public abstract class BaseCommandHandler
    {
        protected readonly ICurrentAccountProvider _CurrentAccountProvider;
        protected readonly IApplicationDbContext _applicationDbContext;

        public BaseCommandHandler(ICurrentAccountProvider currentAccountProvider, IApplicationDbContext applicationDbContext)
        {
            _CurrentAccountProvider = currentAccountProvider;
            _applicationDbContext = applicationDbContext;
        }
    }
}
