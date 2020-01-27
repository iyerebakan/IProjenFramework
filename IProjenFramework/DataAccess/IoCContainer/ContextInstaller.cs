using Autofac;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityRepositories;
using DataAccess.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.IoCContainer
{
    public class ContextInstaller : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<NortwindDbContext>().InstancePerLifetimeScope();
            builder.RegisterType<RepositoryUser>().SingleInstance();
            builder.RegisterType<RepositoryCustomer>().SingleInstance();
        }
    }
}
