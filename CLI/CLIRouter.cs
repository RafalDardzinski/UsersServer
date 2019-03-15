using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CommandLine;
using UsersServer.Database;
using UsersServer.User;

namespace UsersServer.CLI
{
    // Klasa odpowiadająca za wywoływanie funkcji na podstawie przekazanych argumentów.
    class CLIRouter
    {
        public static void Route(string[] args)
        {
            CommandLine.Parser.Default.ParseArguments<DatabaseCreate, UserAdd>(args)
                .MapResult(
                    (DatabaseCreate o) =>
                    {
                        Program.SetupDatabase(o.ServerInstance, o.DatabaseName);
                        return 0;
                    },
                    (UserAdd u) =>
                    {
                        var user = new UserModel
                        {
                            Username = u.Username,
                            Password = u.Password,
                            FirstName = u.FirstName,
                            LastName = u.LastName

                        };

                        Console.WriteLine("Adding user - todo");

                        return 0;
                    },
                    errs => 1
                );
        }
    }
}
