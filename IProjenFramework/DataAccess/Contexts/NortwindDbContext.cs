using Core.Entities.Concrete;
using DataAccess.Utilities;
using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Contexts
{
    public class NortwindDbContext : DbContext
    {
        private readonly AppConfigurationHelper appConfiguration;
        public NortwindDbContext()
        {
            appConfiguration = new AppConfigurationHelper();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(appConfiguration.GetConnectionstring());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
