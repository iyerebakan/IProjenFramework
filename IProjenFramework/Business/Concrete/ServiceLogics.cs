﻿using Autofac;
using Business.Abstract;
using Business.IoCContainer;
using DataAccess.Contexts;
using DataAccess.IoCContainer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public static class ServiceLogics
    {
        public static NortwindDbContext Context { get { return IoCData.Container.Resolve<NortwindDbContext>(); } }

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
    }
}