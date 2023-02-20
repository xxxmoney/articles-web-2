using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Data.Contexts;

namespace Web.Data.Repositories
{
    /// <summary>
    /// Unit of work - used for scoped saving.
    /// Don't forget to dispose.
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Save changes to database.
        /// </summary>
        /// <returns></returns>
        Task CommitAsync();
        /// <summary>
        /// Rollbacks changes.
        /// </summary>
        void Rollback();
    }

    internal class UnitOfWork : IUnitOfWork
    {
        private readonly WebContext context;

        public UnitOfWork(WebContext context)
        {
            this.context = context;
        }

        public Task CommitAsync()
        {
            return this.context.SaveChangesAsync();
        }

        public void Dispose()
        {
            this.context.Dispose();
        }

        public void Rollback()
        {
            this.context.ChangeTracker.Clear();
        }
    }
}
