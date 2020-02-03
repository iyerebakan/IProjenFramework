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
        where TEntity : class, IBaseEntity<TKeyType>
        where TContext : DbContext
    {
        TEntity Get(Expression<Func<TEntity, bool>> condition);
        TEntity GetById(TKeyType id);
        List<TEntity> GetAll(Expression<Func<TEntity, bool>> condition = null);
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void DeleteById(TKeyType id);
        void Delete(TEntity entity);
        IEnumerable<T> Filter<T>(Expression<Func<TEntity, bool>> condition, Expression<Func<TEntity, T>> selector);
        T FilterObject<T>(Expression<Func<TEntity, bool>> condition, Expression<Func<TEntity, T>> selector);
    }
}
