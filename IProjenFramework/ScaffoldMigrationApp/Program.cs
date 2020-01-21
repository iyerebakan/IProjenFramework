using DataAccess.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ScaffoldConsoleApp.Entities;
using ScaffoldMigrationApp.Base;
using ScaffoldMigrationApp.Helpers;
using System;
using System.Linq;

namespace ScaffoldConsoleApp
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            ApplicationContext.ServiceInitializer = ServiceInitialize;
            ConsoleWriter.Write("Started", ConsoleColor.White);

            try
            {
                ApplicationContext.Current.Start(ApplicationStart);
            }
            catch (Exception ex)
            {
                // burada ExceptionHandling uygulanacak
                ConsoleWriter.Error(ex.ToString());
            }
            finally
            {
                ConsoleWriter.Write("Finished", ConsoleColor.White);
                Console.ReadKey();
            }
        }

        private static void ServiceInitialize(IConfiguration config, IServiceCollection serviceCollection, ApplicationContext applicationContext)
        {
            var connectionString = config.GetConnectionString("DefaultConnection");

            serviceCollection.AddDbContext<NortwindContext>(x =>
            {
                x.UseSqlServer(connectionString);
            }, ServiceLifetime.Singleton);            
        }

        private static void ApplicationStart()
        {
            ApplicationContext.Current.ServiceProvider.GetService<NortwindContext>();

            ApplicationContext.Current.Migrate<NortwindContext>(false);
        }

        public static string GetDatabaseName(string connectionStringName)
        {
            var config = ApplicationContext.Current.ServiceProvider.GetService<IConfiguration>();
            var connectionString = config.GetConnectionString(connectionStringName);
            var databaseName = connectionString.Split(";").Where(c => c.Trim().StartsWith("Database=")).Select(c => c.Substring(9).Trim()).FirstOrDefault();

            if (string.IsNullOrWhiteSpace(databaseName))
            {
                throw new NotSupportedException($"{connectionStringName} konfigurasyon adındaki connectionstring içerisinde database adı bulunamadı.");
            }

            return databaseName;
        }
    }
}



//dotnet ef dbcontext scaffold "Server=.;Database=Northwind;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -o Entities -f -c NotrwindContext --data-annotations