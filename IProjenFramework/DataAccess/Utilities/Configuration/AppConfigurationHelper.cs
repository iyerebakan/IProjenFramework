using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DataAccess.Utilities.Configuration
{
    public class AppConfigurationHelper
    {
        private readonly IConfigurationRoot ConfigurationRoot = null;
        public AppConfigurationHelper()
        {
            var configurationBuilder = new ConfigurationBuilder();
            string appsettingsPath = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configurationBuilder.AddJsonFile(appsettingsPath, false);

            ConfigurationRoot = configurationBuilder.Build();
        }

        public string GetConnectionstring()
        {
            var model = ConfigurationRoot.GetSection("ConnectionStrings")
                .GetSection("DefaultConnection");
            return model.Value;
        }
    }
}
