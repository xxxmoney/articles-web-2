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
        IServiceCollection Configure(IServiceCollection serviceCollection);
    }

    public class ContainerSetup : IContainerSetup
    {
        public IServiceCollection Configure(IServiceCollection serviceCollection)
        {
            // Repositories

            // Operations

            // Services
            

            return serviceCollection;
        }
    }
}
