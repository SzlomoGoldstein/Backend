using DotNetMentor.PageMonitor.Application.Interfaces;
using DotNetMentor.PageMonitor.Infrastracture.Auth;

namespace DotNetMentor.PageMonitor.WebApi.Application.Auth
{
    public class JwtAuthenticationDataProvider : IAuthenticationDataProvider
    {
        private readonly JwtManager _jwtManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public JwtAuthenticationDataProvider(JwtManager jwtManager, IHttpContextAccessor httpContextAccessor) 
        {
            _jwtManager = jwtManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public int? GetUserId() 
        {
            var userIdString = GetClaimValue(JwtManager.UserIdClaim);
            if (int.TryParse(userIdString, out int res)) 
            {
                return res;
            }
            return null;
        }

        private string? GetTokenFromCookie() 
        {
            return _httpContextAccessor.HttpContext?.Request.Cookies[CookieSettings.CookieName];
        }

        private string? GetTokenFromHeader() 
        {
            var authorizationHeader = _httpContextAccessor.HttpContext?.Request.Headers["Authorization"].FirstOrDefault();
            if (string.IsNullOrEmpty(authorizationHeader)) 
            {
                return null;
            }
            var splitted = authorizationHeader.Split(' ');
            if (splitted.Length > 1 && splitted[0] == "Bearer") 
            {
                return splitted[1];
            }

            return null;
        }
        private string? GetClaimValue(string claimType) 
        {
            var token = GetTokenFromHeader();
            if (string.IsNullOrEmpty(token)) 
            {
                token = GetTokenFromCookie();
            }

            if (!string.IsNullOrWhiteSpace(token) && _jwtManager.ValidateToken(token)) 
            {
                return _jwtManager.GetClaim(token, claimType);
            }
            return null;
        }
    }
}
