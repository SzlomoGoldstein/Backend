using Azure.Core;
using DotNetMentor.PageMonitor.Application.Logic.Account;
using DotNetMentor.PageMonitor.Application.Logic.User;
using DotNetMentor.PageMonitor.Infrastracture.Auth;
using DotNetMentor.PageMonitor.WebApi.Application.Auth;
using DotNetMentor.PageMonitor.WebApi.Application.Response;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DotNetMentor.PageMonitor.WebApi.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class AccountController : BaseController
    {

        public AccountController(ILogger<AccountController> logger,
            IMediator mediator) : base(logger, mediator)
        {

        }

        [HttpGet]

        public async Task<ActionResult> GetCurrentAccount() 
        {
            var data = await _mediator.Send(new CurrentAccountQuery.Request() { });
            return Ok(data);
        }

    }
}
