using Azure.Core;
using DotNetMentor.PageMonitor.Application.Logic.Account;
using DotNetMentor.PageMonitor.Application.Logic.User;
using DotNetMentor.PageMonitor.Infrastracture.Auth;
using DotNetMentor.PageMonitor.WebApi.Application.Auth;
using DotNetMentor.PageMonitor.WebApi.Application.Response;
using MediatR;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DotNetMentor.PageMonitor.WebApi.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class UserController : BaseController
    {
        private readonly CookieSettings? _cookieSettings;
        private readonly JwtManager _jwtManager;
        private readonly IAntiforgery _antiforgery;
        public UserController(ILogger<UserController> logger, 
                IOptions<CookieSettings> cookieSettings,
            JwtManager jwtManager,
            IAntiforgery antiforgery,
            IMediator mediator) : base(logger, mediator)
        {
            _cookieSettings = cookieSettings != null ? cookieSettings.Value : null;
            _jwtManager = jwtManager;
        }

        [HttpPost]
        [IgnoreAntiforgeryToken]
        public async Task<ActionResult> CreatedUserWithAccount([FromBody] CreateUserWithAccountCommand.Request model) 
        {
            var createAccountResult = await _mediator.Send(model);
            var token = _jwtManager.GenerateUserToken(createAccountResult.UserId);
            SetTokenCookie(token);
            return Ok(new JwtToken() { AccessToken = token });
        }

        [HttpPost]
        public async Task<ActionResult> Login([FromBody] LoginCommand.Request model)
        {
            var loginResult = await _mediator.Send(model);
            var token = _jwtManager.GenerateUserToken(loginResult.UserId);
            SetTokenCookie(token);
            return Ok(new JwtToken() { AccessToken = token });
        }

        [HttpPost]
        public async Task<ActionResult> Logout() 
        {
            var logoutResult = await _mediator.Send(new LogoutCommand.Request());
            DeleteTokenCookie();
            return Ok(logoutResult);
        }

        [HttpGet]

        public async Task<ActionResult> GetLoggedInUser() 
        {
            var data = await _mediator.Send(new LoggedInUserQuery.Request() { });
            return Ok(data);
        }

        [HttpGet]
        public async Task<ActionResult> AntiForgeryToken() 
        {
            var tokens = _antiforgery.GetAndStoreTokens(HttpContext);
            return Ok(tokens.RequestToken);
        }

        private void SetTokenCookie(string token) 
        {
            var cookieOption = new CookieOptions()
            {
                HttpOnly = true,
                Secure = true,
                Expires = DateTime.Now.AddDays(30),
                SameSite = SameSiteMode.Lax,
            };

            if (_cookieSettings != null) 
            {
                cookieOption = new CookieOptions()
                {
                    HttpOnly = cookieOption.HttpOnly,
                    Expires = cookieOption.Expires,
                    Secure = _cookieSettings.Secure,
                    SameSite = _cookieSettings.SameSite,
                };
            }

            Response.Cookies.Append(CookieSettings.CookieName, token, cookieOption);
        }

        private void DeleteTokenCookie() 
        {
            Response.Cookies.Delete(CookieSettings.CookieName, new CookieOptions() 
            {
                HttpOnly = true,
            });
        }
    }
}
