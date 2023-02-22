using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Business.Mappers;
using Web.Business.Operations;
using Web.Data.Contexts;
using Web.Data.Repositories;

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

            // Mappers
            services.AddAutoMapper(typeof(UserMapper));

            // Contexts            
            services.AddDbContext<WebContext>(options =>
            {
                options.UseSqlServer(configuration.ConnectionStrings["Web"]);
            });

            // Repositories (and UnitOfWork)
            services.AddTransient<IUnitOfWorkFactory, UnitOfWorkFactory>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IArticleRepository, ArticleRepository>();

            // Operations
            services.AddScoped<ITokenOperation, TokenOperation>();
            services.AddScoped<IPasswordHashOperation, PasswordHashOperation>();
            services.AddScoped<IUserOperation, UserOperation>();

            // Services

            
            return services;
        }

    }
}
