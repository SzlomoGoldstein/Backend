using DotNetMentor.PageMonitor.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetMentor.PageMonitor.WebApi.Application.Auth
{
    public static class JwtJwtAuthenticationDataProviderConfiguration
    {
        public static IServiceCollection AddJwtAuthenticationDataProvider(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<CookieSettings>(configuration.GetSection("CookieSettings"));
            services.AddScoped<IAuthenticationDataProvider, JwtAuthenticationDataProvider>();
            return services;
        }
    }
}
