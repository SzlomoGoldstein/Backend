using DotNetMentor.PageMonitor.Application.Logic.User;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNetMentor.PageMonitor.WebApi.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class UserController : BaseController
    {
        public UserController(ILogger logger, IMediator mediator) : base(logger, mediator)
        {
        }

        [HttpPost]

        public async Task<ActionResult> CreatedUserWithAccount([FromBody] CreateUserWithAccountCommand.Request model) 
        {
            var createAccountResult = await _mediator.Send(model);
            return Ok(createAccountResult);
        } 
    }
}
