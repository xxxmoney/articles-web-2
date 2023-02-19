using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            // Logger
            var logger = new Logger.LoggerFactory().CreateLogger(configuration.LoggerConfiguration);
            services.AddSingleton(logger);

            // Repositories

            // Operations

            // Services


            return services;
        }
    }
}
