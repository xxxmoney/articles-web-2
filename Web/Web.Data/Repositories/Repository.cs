using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Web.Data.Contexts;

namespace Web.Data.Repositories
{
    /// <summary>
    /// Generic repository with methods for getting, adding and removing entity.
    /// </summary>
    /// <typeparam name="TEntity">Type of entity.</typeparam>
    /// <typeparam name="TIdType">Type of primary key.</typeparam>
    public interface IRepository<TEntity, TIdType> 
        where TEntity : class
    {
        Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null);
        Task<TEntity> GetByIdAsync(TIdType id);
        Task AddAsync(TEntity entity);
        void Remove(TEntity entity);
    }

    public abstract class Repository<TEntity, TIdType> : IRepository<TEntity, TIdType>
        where TEntity : class
    {
        protected readonly DbSet<TEntity> entities;

        public Repository(WebContext dbContext)
        {
            entities = dbContext.Set<TEntity>();
        }

        public Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null)
        {
            IQueryable<TEntity> query = this.entities;

            // Use predicate if present.
            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            return query.ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(TIdType id)
        {
            return await this.entities.FindAsync(id);
        }

        public async Task AddAsync(TEntity entity)
        {
            await entities.AddAsync(entity);
        }

        public void Remove(TEntity entity)
        {
            entities.Remove(entity);
        }
    }
}
