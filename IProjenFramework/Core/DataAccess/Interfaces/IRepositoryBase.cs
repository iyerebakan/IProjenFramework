using Core.Entities;
using Core.Entities.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess.Interfaces
{
    public interface IRepositoryBase<TKeyType, TEntity, TContext>
        where TEntity : class, IEntity<TKeyType>
        where TContext : DbContext
    {
        TContext Context { get; }
        DbSet<TEntity> EntitySet { get; }
        TEntity GetById(TKeyType id);
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void UpdateMap(TEntity entity, Action<TEntity, TEntity> expression);
        void DeleteById(TKeyType id);
        void Delete(TEntity entity);
        IEnumerable<T> Filter<T>(Expression<Func<TEntity, bool>> condition, Expression<Func<TEntity, T>> selector);
        T FilterObject<T>(Expression<Func<TEntity, bool>> condition, Expression<Func<TEntity, T>> selector);
        int Save();
    }
}
