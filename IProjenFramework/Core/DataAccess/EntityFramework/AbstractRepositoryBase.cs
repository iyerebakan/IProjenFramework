using Core.DataAccess.EntityFramework.Interfaces;
using Core.Entities;
using Core.Entities.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.EntityFramework.DataAccess
{
    public abstract class AbstractRepositoryBase<TKeyType, TEntity, TContext> :
        IRepositoryBase<TKeyType, TEntity, TContext>
       where TEntity : class, IBaseEntity<TKeyType>
       where TContext : DbContext
    {
        protected abstract TContext Context { get; }
        private DbSet<TEntity> EntitySet
        {
            get { return this.Context.Set<TEntity>(); }
        }
        public Task<TEntity> Get(Expression<Func<TEntity, bool>> condition)
        {
            return this.Context.Set<TEntity>().Where(condition).SingleOrDefaultAsync();

        }

        public ValueTask<TEntity> GetById(TKeyType id)
        {
            return this.Context.Set<TEntity>().FindAsync(id);
        }

        public Task<List<TEntity>> GetAll(Expression<Func<TEntity, bool>> condition = null)
        {
            return this.Context.Set<TEntity>().Where(condition ?? (k => true)).ToListAsync();
        }

        public Task Insert(TEntity entity)
        {
            this.Context.Entry(entity).State = EntityState.Added;
            return this.Context.SaveChangesAsync();
        }

        public Task Update(TEntity entity)
        {
            this.Context.Entry(entity).State = EntityState.Modified;
            return this.Context.SaveChangesAsync();
        }

        public Task DeleteById(TKeyType id)
        {
            return this.Delete(GetById(id));
        }

        public Task Delete(ValueTask<TEntity> entity)
        {
            this.Context.Entry(entity).State = EntityState.Deleted;
            return this.Context.SaveChangesAsync();
        }

        public Task<List<T>> Filter<T>(Expression<Func<TEntity, bool>> condition, Expression<Func<TEntity, T>> selector)
        {
            return this.Context.Set<TEntity>().Where(condition).Select(selector).ToListAsync();
        }

        public Task<T> FilterObject<T>(Expression<Func<TEntity, bool>> condition, Expression<Func<TEntity, T>> selector)
        {
            return this.Context.Set<TEntity>().Where(condition)
                    .Select(selector).SingleOrDefaultAsync();
        }

    }
}
