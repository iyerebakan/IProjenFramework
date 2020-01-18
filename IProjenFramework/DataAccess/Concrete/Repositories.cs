using Autofac;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityRepositories;
using DataAccess.Contexts;
using DataAccess.IoCContainer;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete
{
    public static class Repositories
    {
        public static NortwindDbContext Context
        {
            get
            {
                return IoCData.Container.Resolve<NortwindDbContext>();
            }
        }

        public static RepositoryUser RepositoryUser
        {
            get
            {
                return IoCData.Container.Resolve<RepositoryUser>();
            }
        }

        public static RepositoryCustomer RepositoryCustomer
        {
            get
            {
                return IoCData.Container.Resolve<RepositoryCustomer>();
            }
        }
    }
}
