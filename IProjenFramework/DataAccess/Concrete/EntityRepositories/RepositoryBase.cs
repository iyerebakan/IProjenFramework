using Autofac;
using Core.DataAccess;
using Core.Entities;
using Core.Entities.Interfaces;
using DataAccess.Contexts;
using DataAccess.IoCContainer;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityRepositories
{
    public class RepositoryBase<TKeyType, TEntity> : AbstractRepositoryBase<TKeyType, TEntity, ProjenFrameworkDbContext>
        where TEntity : class, IBaseEntity<TKeyType>
    {
        public override ProjenFrameworkDbContext Context
        {
            get
            {
                return IoCData.Container.Resolve<ProjenFrameworkDbContext>();
            }
        }
    }
}
