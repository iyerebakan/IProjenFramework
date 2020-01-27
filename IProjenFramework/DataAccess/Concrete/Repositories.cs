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
        public static ProjenFrameworkDbContext Context
        {
            get
            {
                return IoCData.Container.Resolve<ProjenFrameworkDbContext>();
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

        public static RepositoryCountry RepositoryCountry
        {
            get
            {
                return IoCData.Container.Resolve<RepositoryCountry>();
            }
        }

        public static RepositoryCity RepositoryCity
        {
            get
            {
                return IoCData.Container.Resolve<RepositoryCity>();
            }
        }

        public static RepositoryDistrict RepositoryDistrict
        {
            get
            {
                return IoCData.Container.Resolve<RepositoryDistrict>();
            }
        }

        public static RepositoryForm RepositoryForm
        {
            get
            {
                return IoCData.Container.Resolve<RepositoryForm>();
            }
        }

        public static RepositoryDesignGroup RepositoryDesignGroup
        {
            get
            {
                return IoCData.Container.Resolve<RepositoryDesignGroup>();
            }
        }

        public static RepositoryDesignGroupDetail RepositoryDesignGroupDetail
        {
            get
            {
                return IoCData.Container.Resolve<RepositoryDesignGroupDetail>();
            }
        }
    }
}
