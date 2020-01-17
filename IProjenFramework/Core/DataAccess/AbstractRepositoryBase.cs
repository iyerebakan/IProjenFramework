using Core.DataAccess.Interfaces;
using Core.Entities;
using Core.Entities.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{
    public abstract class AbstractRepositoryBase<TKeyType, TEntity, TContext> : IRepositoryBase<TKeyType, TEntity, TContext>
       where TEntity : class, IBaseEntity<TKeyType>
       where TContext : DbContext
    {

        public abstract TContext Context
        {
            get;
        }

        public DbSet<TEntity> EntitySet
        {
            get { return this.Context.Set<TEntity>(); }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> condition)
        {
            return this.EntitySet.Where(condition).SingleOrDefault();
        }
        public TEntity GetById(TKeyType id)
        {
            return this.EntitySet.Find(id);
        }

        public void Insert(TEntity entity)
        {
            this.EntitySet.Add(entity);
        }

        public void Update(TEntity entity)
        {
            this.Context.Entry(entity).State = EntityState.Modified;
        }

        public void UpdateMap(TEntity entity, Action<TEntity, TEntity> expression)
        {
            if (entity.Id.Equals(default(TKeyType)))
            {
                throw new Exception("Update için entity id doldurulmalıdır.");
            }

            var dbEntity = this.GetById(entity.Id);

            expression.Invoke(entity, dbEntity);
            this.Update(dbEntity);
        }

        public void DeleteById(TKeyType id)
        {
            this.Delete(this.GetById(id));
        }

        public void Delete(TEntity entity)
        {
            this.Context.Entry(entity).State = EntityState.Deleted;
        }

        public IEnumerable<T> Filter<T>(Expression<Func<TEntity, bool>> condition, Expression<Func<TEntity, T>> selector)
        {
            return this.EntitySet.Where(condition).Select(selector);
        }

        public T FilterObject<T>(Expression<Func<TEntity, bool>> condition, Expression<Func<TEntity, T>> selector)
        {
            return this.EntitySet.Where(condition).Select(selector).SingleOrDefault();
        }

        public int Save()
        {
            if (this.Context.ChangeTracker.HasChanges())
            {
                return this.Context.SaveChanges();
            }

            return -1;
        }

    }
}
