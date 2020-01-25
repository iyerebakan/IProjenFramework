using Autofac;
using System;
using System.Collections.Generic;
using System.Reflection;
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
                    builder.RegisterModule(new ServiceInstaller());
                    _container = builder.Build();
                }

                return _container;
            }
        }
    }
}
