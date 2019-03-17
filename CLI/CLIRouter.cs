using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CommandLine;
using UsersServer.CLI.Options;
using UsersServer.Database;
using UsersServer.User;

namespace UsersServer.CLI
{
    // Klasa odpowiadająca za wywoływanie funkcji na podstawie przekazanych argumentów.
    class CLIRouter
    {
        public static void Route(string[] args)
        {
            CommandLine.Parser.Default.ParseArguments<
                    DatabaseCreate, 
                    UserCreate, 
                    UserRead>(args)
                .MapResult(
                    (DatabaseCreate o) =>
                    {
                        MsSqlDatabaseManager.Create(o.ServerInstance, o.DatabaseName);
                        return 0;
                    },
                    (UserCreate u) =>
                    {
                        User.User.Create(u.FirstName, u.LastName, u.Username, u.Password);
                        return 0;
                    },
                    (UserRead c) =>
                    {
                        var users = User.User.Read(c.Id, c.FirstName, c.LastName, c.Username);
                        DataDisplayer.Display(users);
                        return 0;
                    },
                    errs => 1
                );
        }
    }
}
