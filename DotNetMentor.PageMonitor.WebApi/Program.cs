using Serilog;
using DotNetMentor.PageMonitor.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetMentor.PageMonitor.Infrastracture.Persistance;
using DotNetMentor.PageMonitor.Application.Logic.Abstractions;
using DotNetMentor.PageMonitor.WebApi.Middlewares;
using DotNetMentor.PageMonitor.Application;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DotNetMentor.PageMonitor.Infrastracture.Auth;

namespace DotNetMentor.PageMonitor.WebApi
{
    public class Program
    {
        public static string APP_NAME = "DotNetMentor.PageMonitor.WebApi";
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .Enrich.WithProperty("Application", APP_NAME)
                .Enrich.WithProperty("MachineName", Environment.MachineName)
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .CreateBootstrapLogger();

            var builder = WebApplication.CreateBuilder(args);

            if (builder.Environment.IsDevelopment()) 
            {
                builder.Configuration.AddJsonFile("appsetting.Development.local.json");
            }

            builder.Host.UseSerilog((context, services, configuration) => configuration
                .Enrich.WithProperty("Application", APP_NAME)
                .Enrich.WithProperty("MachineName", Environment.MachineName)
                .ReadFrom.Configuration(context.Configuration)
                .ReadFrom.Services(services)
                .Enrich.FromLogContext());

            // Add services to the container.
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddDatabaseCache();
            builder.Services.AddSqlDatabase(builder.Configuration.GetConnectionString("MainDbSql"));
            builder.Services.AddControllers();
            builder.Services.AddJwtAuth(builder.Configuration);

            builder.Services.AddMediatR(c =>
            {
                c.RegisterServicesFromAssemblyContaining(typeof(BaseCommandHandler));
            });

            builder.Services.AddApplicationServices();

            var app = builder.Build();

            app.UseExceptionResultMiddleware();

            // Configure the HTTP request pipeline.

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}