using JepcoBackEndSystemProject.Data;


using JepcoBackEndSystemProject.Models.Models;
using JepcoBackEndSysytemProject.LoggerService;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using JepcoBackEndSystemProject.Data.CommonReturn;

namespace JepcoBackEndSystemProject.Services.Extensions
{
    public static  class ServiceExtensions
    {

        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
        }
        public static void ConfigureIISIntegration(this IServiceCollection services)
        {
            services.Configure<IISOptions>(options =>
            {
                
            });
        }
        public static void ConfigureLoggerService(this IServiceCollection services)
        {
            services.AddSingleton<ILoggerManager, LoggerManager>();
        }
        public static void ConfigureMsSqlContext(this IServiceCollection services, IConfiguration config)
        {
            string connectionString = config.GetConnectionString("JepcoDBContext");
            services.AddDbContext<DBJEPCOBackEndContext>(Option => Option.UseSqlServer(connectionString));
        }
        public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
           
        }
        public static void ConfigureCommorReturn(this IServiceCollection services)
        {
            services.AddSingleton<ICommonReturn, CommonReturn>();
        }
    }   
}
