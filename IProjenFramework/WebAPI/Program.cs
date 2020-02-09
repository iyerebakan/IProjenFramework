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

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
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
                     webBuilder.UseUrls("http://localhost:7002");
                     webBuilder.UseStartup<Startup>();
                 });
    }
}


