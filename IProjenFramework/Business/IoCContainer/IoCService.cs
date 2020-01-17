﻿using Autofac;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.IoCContainer
{
    public static class IoCService
    {
        private static IContainer _container;

        public static IContainer Container
        {
            get
            {
                if (_container == null)
                {
                    var builder = new ContainerBuilder();
                    builder.RegisterModule(new ContextInstaller());
                    _container = builder.Build();
                }

                return _container;
            }
        }
    }
}