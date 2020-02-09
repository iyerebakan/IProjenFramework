using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Auth;
using Core.DependencyResolvers;
using Core.Extensions;
using Core.Utilities.IoC;
using DataAccess.Contexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace IdentityServer
{
    public class Startup : CoreStartup
    {
        public Startup(IConfiguration configuration) : base(configuration)
        {

        }

        protected override void AddDbContext(IServiceCollection services)
        {
            services.AddDbContext<ProjenFrameworkDbContext>(options =>
               options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")),
               ServiceLifetime.Scoped);
        }

    }
}