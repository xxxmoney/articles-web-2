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

    public abstract class DatabaseRepository<TEntity, TIdType> : IRepository<TEntity, TIdType>
        where TEntity : class
    {
        protected readonly WebContext context;
        protected readonly DbSet<TEntity> entities;
        protected readonly Expression<Func<TEntity, object>>[] includes;

        public DatabaseRepository(WebContext context, params Expression<Func<TEntity, object>>[] includes)
        {
            this.context = context;
            this.entities = context.Set<TEntity>();
            this.includes = includes;
        }

        public Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null)
        {
            IQueryable<TEntity> query = this.entities;

            // Use includes.
            foreach (var include in this.includes)
            {
                query = query.Include(include);
            }

            // Use predicate if present.
            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            return query.ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(TIdType id)
        {
            var entity = await this.entities.FindAsync(id);

            // Use includes if entity found.
            if (entity != null)
            {
                var query = context.Set<TEntity>().AsQueryable();
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
                await query.LoadAsync();
            }
            
            return entity;
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
