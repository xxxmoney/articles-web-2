using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Data.Contexts;

namespace Web.Data.Repositories
{
    /// <summary>
    /// Factory for creating UnitOfWork instances in scoped manner - with using.
    /// </summary>
    public interface IUnitOfWorkFactory
    {
        /// <summary>
        /// Creates an instance of unit of work.
        /// Be sure to dispose it after use - preferable usage with using.
        /// </summary>
        /// <returns></returns>
        IUnitOfWork Create();
    }

    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        private readonly WebContext context;

        public UnitOfWorkFactory(WebContext context)
        {
            this.context = context;
        }

        public IUnitOfWork Create()
        {
            return new UnitOfWork(this.context);
        }
    }
}
