using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;
using NHibernate.Cfg;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Tool.hbm2ddl;
using UsersServer.CLI;
using UsersServer.Database;
using UsersServer.User;

namespace UsersServer
{
    class Program
    {
        
        static void Main(string[] args)
        {
                CLIRouter.Route(args);
            try
            {
            }
            catch (Exception e)
            {
                ErrorHandler.ErrorHandler.Handle(e);
            }
        }

        public static void CreateDatabase(string serverInstance, string dbName)
        {
            var newDatabaseConnectionString = MsSqlDatabaseManager.Create(serverInstance, dbName);
            new MsSqlDatabaseManager(newDatabaseConnectionString).SetupSchema();
            Logger.Log($"Database {dbName} created successfully.");
            AppConfigManager.SetConnectionString(newDatabaseConnectionString);
        }

    }
}
