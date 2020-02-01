﻿using Autofac;
using Business.Abstract;
using Business.IoCContainer;
using Core.Utilities.Security.Jwt;
using DataAccess.Contexts;
using DataAccess.IoCContainer;
using Entities.Entities.EntityUser;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public static class ServiceLogics
    {
        public static ProjenFrameworkDbContext Context { get { return IoCData.Container.Resolve<ProjenFrameworkDbContext>(); } }
        public static ITokenHelper<User, OperationClaim> TokenHelper
        {
            get
            {
                return IoCService.Container.Resolve<ITokenHelper<User,OperationClaim>>();
            }
        }
        public static IUserService UserManager
        {
            get
            {
                return IoCService.Container.Resolve<IUserService>();
            }
        }
        public static IAuthService AuthManager
        {
            get
            {
                return IoCService.Container.Resolve<IAuthService>();
            }
        }
        public static ICustomerService CustomerManager
        {
            get
            {
                return IoCService.Container.Resolve<ICustomerService>();
            }
        }
        public static IAddressService AddressManager
        {
            get
            {
                return IoCService.Container.Resolve<IAddressService>();
            }
        }
        public static IFormService FormManager
        {
            get
            {
                return IoCService.Container.Resolve<IFormService>();
            }
        }

    }
}
