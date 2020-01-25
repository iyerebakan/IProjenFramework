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
            builder.RegisterType<NortwindDbContext>().As<NortwindDbContext>().InstancePerLifetimeScope();
            builder.RegisterType<RepositoryUser>().As<RepositoryUser>().SingleInstance();
            builder.RegisterType<RepositoryCustomer>().As<RepositoryCustomer>().SingleInstance();
            builder.RegisterType<RepositoryCountry>().SingleInstance();
        }
    }
}
