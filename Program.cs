using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;
using NHibernate.Mapping.ByCode.Conformist;
using UsersServer.Database;
using UsersServer.User;

namespace UsersServer
{
    class Program
    {
        
        static void Main(string[] args)
        {

            var dbConfiguration = new MsSqlConfiguration(@"Server=localhost\SQLEXPRESS;Integrated Security=True");
            var sessionManager = new MsSqlSessionManager(dbConfiguration);
            var databaseManager = new MsSqlDatabaseManager(sessionManager);
            databaseManager.CreateDatabase("new db");



            //CommandLine.Parser.Default.ParseArguments<Options, DatabaseOptions>(args)
            //    .MapResult(
            //    (Options o) => 0,
            //    (DatabaseOptions dbo) => 0,
            //    errs => 1
            //);
        }
    }
}
