using Core.Entities.Concrete;
using DataAccess.Utilities;
using Entities.Entities.EntityForm;
using EntityCustomer.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Contexts
{
    public class ProjenFrameworkDbContext : DbContext
    {
        private readonly AppConfigurationHelper appConfiguration;
        public ProjenFrameworkDbContext()
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
        public DbSet<CustomerAddress> CustomerAddresses { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Form> Forms { get; set; }
        public DbSet<DesignGroup> DesignGroups { get; set; }
        public DbSet<DesignGroupDetail> DesignGroupDetails { get; set; }
    }
}
