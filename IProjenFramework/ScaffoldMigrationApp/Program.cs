using DataAccess.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ScaffoldConsoleApp.Entities;
using System;
using System.Linq;

namespace ScaffoldConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var appConfiguration = new AppConfigurationHelper();

            DbContextOptionsBuilder<NortwindContext> optionsBuilder = new DbContextOptionsBuilder<NortwindContext>()
                .UseSqlServer(appConfiguration.GetConnectionstring());

            using (NortwindContext sc = new NortwindContext(optionsBuilder.Options))
            {

                sc.Database.Migrate();
                sc.Districts.ToList();
            }
        }
    }
}



//dotnet ef dbcontext scaffold "Server=.;Database=Northwind;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -o Entities -f -c NotrwindContext --data-annotations