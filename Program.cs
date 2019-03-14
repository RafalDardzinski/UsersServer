using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;
using NHibernate.Cfg;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Tool.hbm2ddl;
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
                CommandLine.Parser.Default.ParseArguments<DatabaseCreate, Options>(args)
                    .MapResult(
                        (DatabaseCreate o) =>
                        {
                            SetupDatabase(o.ServerInstance, o.DatabaseName);
                            return 0;
                        },
                        errs => 1
                    );
            }
            catch (Exception e)
            {
                ErrorHandler.ErrorHandler.Handle(e);
            }

            //SetupDatabase(@"localhost\SQLEXPRESS", "natalie-portman3");
        }

        static void SetupDatabase(string serverInstance, string dbName)
        {
            var connectionString = MsSqlDatabaseManager.Create(serverInstance, dbName);
            var models = MappingCompiler.CompileModels();
            var configuration = new MsSqlConfiguration(connectionString, models);
            new SchemaExport(configuration).Create(false, true);
            Console.WriteLine($@"{dbName}@{serverInstance} has been setup successfully!");
        }

    }
}
