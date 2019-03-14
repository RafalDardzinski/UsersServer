using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;

namespace UsersServer.CLI
{
    // Klasa odpowiadająca za wywoływanie funkcji na podstawie przekazanych argumentów.
    class CLIRouter
    {
        public static void Route(string[] args)
        {
            CommandLine.Parser.Default.ParseArguments<DatabaseCreate, Options>(args)
                .MapResult(
                    (DatabaseCreate o) =>
                    {
                        Program.SetupDatabase(o.ServerInstance, o.DatabaseName);
                        return 0;
                    },
                    errs => 1
                );
        }
    }
}
