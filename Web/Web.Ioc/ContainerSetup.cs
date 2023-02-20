using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Business.Operations;
using Web.Data.Contexts;

namespace Web.Ioc
{
    public interface IContainerSetup
    {
        IServiceCollection Configure(IServiceCollection services, Configuration configuration);
    }

    public class ContainerSetup : IContainerSetup
    {
        public IServiceCollection Configure(IServiceCollection services, Configuration configuration)
        {
            // Configuration
            services.AddSingleton(configuration);

            // Logger
            if (configuration.UseLogger)
            {
                var logger = new Logger.LoggerFactory().CreateLogger(configuration.Logger);
                services.AddSingleton(logger);
            }

            // Contexts            
            services.AddDbContext<WebContext>(options =>
            {
                options.UseSqlServer(configuration.ConnectionStrings["Web"]);
            });

            // Repositories

            // Operations
            services.AddScoped<ITokenOperation, TokenOperation>();
            services.AddScoped<IPasswordHashOperation, PasswordHashOperation>();

            // Services


            return services;
        }

    }
}
