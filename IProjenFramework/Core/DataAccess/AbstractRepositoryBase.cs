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
    public abstract class AbstractRepositoryBase<TKeyType, TEntity, TContext> :
        IRepositoryBase<TKeyType, TEntity, TContext>
       where TEntity : class, IBaseEntity<TKeyType>
       where TContext : DbContext, new()
    {
        public TEntity Get(Expression<Func<TEntity, bool>> condition)
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>().Where(condition).SingleOrDefault();
            } 
        }

        public TEntity GetById(TKeyType id)
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>().Find(id);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> condition = null)
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>().Where(condition ?? (k => true)).ToList();
            }
        }

        public void Insert(TEntity entity)
        {
            using (var context = new TContext())
            {
                context.Entry(entity).State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Update(TEntity entity)
        {
            using (var context = new TContext())
            {
                context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeleteById(TKeyType id)
        {
            this.Delete(this.GetById(id));
        }

        public void Delete(TEntity entity)
        {
            using (var context = new TContext())
            {
                context.Entry(entity).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public IEnumerable<T> Filter<T>(Expression<Func<TEntity, bool>> condition, Expression<Func<TEntity, T>> selector)
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>().Where(condition).Select(selector);
            }
        }

        public T FilterObject<T>(Expression<Func<TEntity, bool>> condition, Expression<Func<TEntity, T>> selector)
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>().Where(condition).Select(selector).SingleOrDefault();
            }
        }

    }
}
