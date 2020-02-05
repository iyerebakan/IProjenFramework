using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.IoCContainer;
using DataAccess.IoCContainer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Topshelf;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
            HostFactory.Run(windowsService =>
            {
                windowsService.Service<WebServer>(s =>
                {
                    s.ConstructUsing(service => new WebServer());
                    s.WhenStarted(service => service.Start());
                    s.WhenStopped(service => service.Stop());
                });

                windowsService.RunAsLocalSystem();
                windowsService.StartAutomatically();

                windowsService.SetDescription("IProjenFramework.WebAPI Service");
                windowsService.SetDisplayName("IProjenFramework.WebAPI Service");
                windowsService.SetServiceName("IProjenFramework.WebAPI");
            });
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
             Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder(args)
                 .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                 .ConfigureContainer<ContainerBuilder>(builder =>
                 {
                     builder.RegisterModule(new ServiceInstaller())
                     .RegisterModule(new ContextInstaller());
                 })
                 .ConfigureWebHostDefaults(webBuilder =>
                 {
                     webBuilder.UseStartup<Startup>();
                 });
    }
}


