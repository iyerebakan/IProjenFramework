using Autofac;
using Core.DataAccess;
using Core.Entities;
using Core.Entities.Interfaces;
using Core.EntityFramework.DataAccess;
using Core.Utilities.IoC;
using DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityRepositories
{
    public class RepositoryBase<TKeyType, TEntity> : AbstractRepositoryBase<TKeyType, TEntity, ProjenFrameworkDbContext>
        where TEntity : class, IBaseEntity<TKeyType>
    {
        protected override ProjenFrameworkDbContext Context
        {
            get
            {
                return ServiceTool.ServiceProvider.GetService<ProjenFrameworkDbContext>();
            }
        }
    }
}
