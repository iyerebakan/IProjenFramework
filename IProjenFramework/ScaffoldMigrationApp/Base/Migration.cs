using Microsoft.EntityFrameworkCore;
using ScaffoldMigrationApp.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScaffoldMigrationApp.Base
{
    public abstract class Migration<TContext> where TContext : DbContext
    {
        public delegate void MigrationEventHandler(TContext dbContext);

#pragma warning disable S3264 // Events should be invoked

        public event MigrationEventHandler OnBeforeDatabaseReset
#pragma warning restore S3264 // Events should be invoked
        {
            add
            {
                ApplicationContext.Current.AddEvent(ApplicationContext.Current.OnBeforeDatabaseReset, this.GetType(), value);
            }
            remove
            {
                ApplicationContext.Current.RemoveEvent(ApplicationContext.Current.OnBeforeDatabaseReset, this.GetType(), value);
            }
        }

#pragma warning disable S3264 // Events should be invoked

        public event MigrationEventHandler OnAfterDatabaseReset
#pragma warning restore S3264 // Events should be invoked
        {
            add
            {
                ApplicationContext.Current.AddEvent(ApplicationContext.Current.OnAfterDatabaseReset, this.GetType(), value);
            }
            remove
            {
                ApplicationContext.Current.RemoveEvent(ApplicationContext.Current.OnAfterDatabaseReset, this.GetType(), value);
            }
        }

#pragma warning disable S3264 // Events should be invoked

        public event MigrationEventHandler OnBeforeDatabaseMigrate
#pragma warning restore S3264 // Events should be invoked
        {
            add
            {
                ApplicationContext.Current.AddEvent(ApplicationContext.Current.OnBeforeDatabaseMigrate, this.GetType(), value);
            }
            remove
            {
                ApplicationContext.Current.RemoveEvent(ApplicationContext.Current.OnBeforeDatabaseMigrate, this.GetType(), value);
            }
        }

#pragma warning disable S3264 // Events should be invoked

        public event MigrationEventHandler OnAfterDatabaseMigrate
#pragma warning restore S3264 // Events should be invoked
        {
            add
            {
                ApplicationContext.Current.AddEvent(ApplicationContext.Current.OnAfterDatabaseMigrate, this.GetType(), value);
            }
            remove
            {
                ApplicationContext.Current.RemoveEvent(ApplicationContext.Current.OnAfterDatabaseMigrate, this.GetType(), value);
            }
        }

        protected Migration()
        {
            OnBeforeDatabaseReset += Migration_OnBeforeDatabaseReset;
            OnAfterDatabaseReset += Migration_OnAfterDatabaseReset;
            OnBeforeDatabaseMigrate += Migration_OnBeforeDatabaseMigrate;
            OnAfterDatabaseMigrate += Migration_OnAfterDatabaseMigrate;

            // seed methodu kullanılması en olası method olduğu için otomatik olarak bind edilmiştir.
            OnAfterDatabaseMigrate += Seed;
        }

        private void ConsoleLog(string eventName)
        {
            ConsoleWriter.Default("");
            ConsoleWriter.Default("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
            ConsoleWriter.Write("ContextName: ", ConsoleColor.DarkGray);
            ConsoleWriter.Write(typeof(TContext).Name, ConsoleColor.White);
            Console.WriteLine();
            ConsoleWriter.Write($"MigrationClass: ", ConsoleColor.DarkGray);
            ConsoleWriter.Write(this.GetType().Name, ConsoleColor.White);
            Console.WriteLine();
            ConsoleWriter.Write($"Context: ", ConsoleColor.DarkGray);
            ConsoleWriter.Write(typeof(TContext).Name, ConsoleColor.White);
            Console.WriteLine();
            ConsoleWriter.Write($"Event: ", ConsoleColor.DarkGray);
            ConsoleWriter.Write(eventName, ConsoleColor.White);
            Console.WriteLine();
            ConsoleWriter.Default("============================================================");
            ConsoleWriter.Default("");
        }

        private void Migration_OnBeforeDatabaseReset(TContext dbContext)
        {
            ConsoleLog("OnBeforeDatabaseReset");
        }

        private void Migration_OnAfterDatabaseReset(TContext dbContext)
        {
            ConsoleLog("OnAfterDatabaseReset");
        }

        private void Migration_OnBeforeDatabaseMigrate(TContext dbContext)
        {
            ConsoleLog("OnBeforeDatabaseMigrate");
        }

        private void Migration_OnAfterDatabaseMigrate(TContext dbContext)
        {
            ConsoleLog("OnAfterDatabaseMigrate");
        }

        public virtual void Seed(TContext context)
        {
        }
    }
}
