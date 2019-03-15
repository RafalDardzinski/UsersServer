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
            try
            {
                CLIRouter.Route(args);
            }
            catch (Exception e)
            {
                ErrorHandler.ErrorHandler.Handle(e);
            }

            
        }

        public static void SetupDatabase(string serverInstance, string dbName)
        {
            var connectionString = MsSqlDatabaseManager.Create(serverInstance, dbName);
            var models = MappingCompiler.CompileModels();
            var configuration = new MsSqlConfiguration(connectionString, models);
            new SchemaExport(configuration).Create(false, true);
            Console.WriteLine($@"{dbName}@{serverInstance} has been setup successfully!");
        }

    }
}
