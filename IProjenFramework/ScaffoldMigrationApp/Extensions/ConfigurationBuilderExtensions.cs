using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScaffoldMigrationApp.Extensions
{
    public static class ConfigurationBuilderExtensions
    {
        public static IConfigurationBuilder BuildConfiguration(this IConfigurationBuilder builder, string contentRootPath, string environmentName)
        {
            builder.SetBasePath(contentRootPath)
             .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
             .AddEnvironmentVariables();
            if (!string.IsNullOrWhiteSpace(environmentName))
            {
                builder.AddJsonFile($"appsettings.{environmentName}.json", optional: true, reloadOnChange: true);
                builder.AddJsonFile($"appsettings.{environmentName}.Additional.json", optional: true, reloadOnChange: true);
            }

            return builder;
        }
    }
}
