using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Auth;
using Core.DependencyResolvers;
using Core.Extensions;
using Core.Utilities.IoC;
using Core.Utilities.Security.Encryption;
using Core.Utilities.Security.Jwt;
using DataAccess.Contexts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace WebAPI
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

        protected override void ConfigureServiceMain(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "IdentityServer Microservice", Version = "v1" });
            });

            services.AddDependencyResolvers(new ICoreModule[]
            {
                new CoreModule()
            });

            base.ConfigureServiceMain(services);
        }
    }
}
