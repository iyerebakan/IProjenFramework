using Autofac;
using Core.Entities.Concrete;
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
            builder.RegisterType<RepositoryCity>();
            builder.RegisterType<RepositoryCountry>();
            builder.RegisterType<RepositoryCustomer>();
            builder.RegisterType<RepositoryDesignGroup>();
            builder.RegisterType<RepositoryDesignGroupDetail>();
            builder.RegisterType<RepositoryDistrict>();
            builder.RegisterType<RepositoryForm>();
            builder.RegisterType<RepositoryUser>();
        }
    }
}
