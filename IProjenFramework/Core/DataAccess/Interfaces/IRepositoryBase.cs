using Core.Entities;
using Core.Entities.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.Interfaces
{
    public interface IRepositoryBase<TKeyType, TEntity, TContext>
        where TEntity : class, IBaseEntity<TKeyType>
        where TContext : DbContext
    {
        Task<TEntity> Get(Expression<Func<TEntity, bool>> condition);
        ValueTask<TEntity> GetById(TKeyType id);
        Task<List<TEntity>> GetAll(Expression<Func<TEntity, bool>> condition = null);
        Task Insert(TEntity entity);
        Task Update(TEntity entity);
        Task DeleteById(TKeyType id);
        Task Delete(ValueTask<TEntity> entity);
        Task<List<T>> Filter<T>(Expression<Func<TEntity, bool>> condition, Expression<Func<TEntity, T>> selector);
        Task<T> FilterObject<T>(Expression<Func<TEntity, bool>> condition, Expression<Func<TEntity, T>> selector);
    }
}
