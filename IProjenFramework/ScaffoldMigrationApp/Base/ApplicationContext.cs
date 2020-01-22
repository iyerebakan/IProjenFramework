using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ScaffoldMigrationApp.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ScaffoldMigrationApp.Base
{
    public class ApplicationContext
    {
        private static Lazy<ApplicationContext> applicationContextSingleton = new Lazy<ApplicationContext>(() => ApplicationContext.ApplicationContextFactory(), true);
        public static ApplicationContext Current { get { return ApplicationContext.applicationContextSingleton.Value; } }
        private static IEnumerable<Type> MigrationTypes = typeof(Migration<>).Assembly.GetTypes().Where(c => c.BaseType.IsGenericType && c.BaseType.GetGenericTypeDefinition() == typeof(Migration<>));
        public static Action<IConfiguration, ServiceCollection, ApplicationContext> ServiceInitializer { get; set; }



        public ServiceProvider ServiceProvider { get; set; }
        public IEnumerable<object> MigrationInstances { get; set; }

        public Dictionary<Type, Delegate> OnBeforeDatabaseReset { get; set; } = new Dictionary<Type, Delegate>();
        public Dictionary<Type, Delegate> OnAfterDatabaseReset { get; set; } = new Dictionary<Type, Delegate>();
        public Dictionary<Type, Delegate> OnBeforeDatabaseMigrate { get; set; } = new Dictionary<Type, Delegate>();
        public Dictionary<Type, Delegate> OnAfterDatabaseMigrate { get; set; } = new Dictionary<Type, Delegate>();

        public ApplicationContext()
        {
        }

        public static ApplicationContext ApplicationContextFactory()
        {
            var config = new ConfigurationBuilder().BuildConfiguration(Directory.GetCurrentDirectory(), "appsettings.json").Build();
            var serviceCollection = new ServiceCollection();
            var applicationContext = new ApplicationContext();

            serviceCollection.AddSingleton<IConfiguration>(config);

            foreach (var migrationType in MigrationTypes)
            {
                serviceCollection.AddSingleton(migrationType);
            }

            ServiceInitializer?.Invoke(config, serviceCollection, applicationContext);
            applicationContext.ServiceProvider = serviceCollection.BuildServiceProvider();

            return applicationContext;
        }

        public void Migrate<TContext>(bool databaseReset = false) where TContext : DbContext
        {
            var context = this.ServiceProvider.GetService<TContext>();
            var contextType = context.GetType();

            if (databaseReset)
            {
                this.BeforeDatabaseReset(contextType, context);
                this.DatabaseReset(context);
                this.AfterDatabaseReset(contextType, context);
                this.BeforeDatabaseMigrate(contextType, context);

                context.Database.EnsureCreated();

                this.AfterDatabaseMigrate(contextType, context);

            }
            else
            {
                this.BeforeDatabaseMigrate(contextType, context);
                context.Database.Migrate();
                this.AfterDatabaseMigrate(contextType, context);
                
            }

            
        }

        public void MigrateAndCreateViews<TContext>(bool databaseReset = false, Dictionary<string, string> viewQueryParams = null) where TContext : DbContext
        {
            var context = this.ServiceProvider.GetService<TContext>();
            var contextType = context.GetType();

            if (databaseReset)
            {
                this.BeforeDatabaseReset(contextType, context);
                this.DatabaseReset(context);
                this.AfterDatabaseReset(contextType, context);
            }

            this.BeforeDatabaseMigrate(contextType, context);

            context.Database.EnsureCreated();

            this.AfterDatabaseMigrate(contextType, context);
        }

        public virtual void BeforeDatabaseReset(Type contextType, DbContext dbContext)
        {
            if (OnBeforeDatabaseReset.ContainsKey(contextType))
            {
                OnBeforeDatabaseReset[contextType]?.DynamicInvoke(dbContext);
            }
        }

        public void DatabaseReset(DbContext context)
        {
#pragma warning disable SCS0018 // Path traversal: injection possible in {1} argument passed to '{0}'
            var streamReader = File.OpenText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Scripts", "ResetDB.sql"));
#pragma warning restore SCS0018 // Path traversal: injection possible in {1} argument passed to '{0}'
            var script = streamReader.ReadToEnd();

            var connection = context.Database.GetDbConnection();
            connection.Open();

            using (var transaction = connection.BeginTransaction())
            {
                var statements = Regex.Split(script,
                                             @"GO|(--.+)",
                                             RegexOptions.Multiline |
                                             RegexOptions.IgnorePatternWhitespace |
                                             RegexOptions.IgnoreCase);
                foreach (var statement in statements)
                {
                    var command = connection.CreateCommand();

#pragma warning disable SCS0026 // Possible SQL injection
                    command.CommandText = statement;
#pragma warning restore SCS0026 // Possible SQL injection
                    command.Transaction = transaction;

                    command.ExecuteNonQuery();
                }

                transaction.Commit();
            }

            connection.Close();
        }

        public virtual void AfterDatabaseReset(Type contextType, DbContext dbContext)
        {
            if (OnAfterDatabaseReset.ContainsKey(contextType))
            {
                OnAfterDatabaseReset[contextType]?.DynamicInvoke(dbContext);
            }
        }

        public virtual void BeforeDatabaseMigrate(Type contextType, DbContext dbContext)
        {
            if (OnBeforeDatabaseMigrate.ContainsKey(contextType))
            {
                OnBeforeDatabaseMigrate[contextType]?.DynamicInvoke(dbContext);
            }
        }

        public virtual void AfterDatabaseMigrate(Type contextType, DbContext dbContext)
        {
            if (OnAfterDatabaseMigrate.ContainsKey(contextType))
            {
                OnAfterDatabaseMigrate[contextType]?.DynamicInvoke(dbContext);
            }
        }

        public void AddEvent(Dictionary<Type, Delegate> delegateDictionary, Type migrationType, Delegate delegateMethod)
        {
            var contextType = migrationType.BaseType.GetGenericArguments().First();

            if (!delegateDictionary.ContainsKey(contextType))
            {
                delegateDictionary.Add(contextType, delegateMethod);
            }
            else
            {
                delegateDictionary[contextType] = Delegate.Combine(delegateDictionary[contextType], delegateMethod);
            }
        }

        public void RemoveEvent(Dictionary<Type, Delegate> delegateDictionary, Type migrationType, Delegate delegateMethod)
        {
            var contextType = migrationType.BaseType.GetGenericArguments().First();

            if (!delegateDictionary.ContainsKey(contextType))
            {
                delegateDictionary.Add(contextType, delegateMethod);
            }
            else
            {
                delegateDictionary[contextType] = Delegate.Remove(delegateDictionary[contextType], delegateMethod);
            }
        }

        public void Start(Action applicationStart = null)
        {
            this.MigrationInstances = ApplicationContext.MigrationTypes.Select(c => this.ServiceProvider.GetService(c)).ToArray();

            applicationStart?.Invoke();
        }
    }
}
