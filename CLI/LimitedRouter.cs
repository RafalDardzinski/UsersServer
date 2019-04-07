using CommandLine;
using UsersServer.AppConfig;
using UsersServer.CLI.Options;
using UsersServer.Database;
using UsersServer.Logger;

namespace UsersServer.CLI
{
    class LimitedRouter : Router, ICommandLineRouter
    {

        public LimitedRouter(ILogger logger, IDatabase database, IConfigManager configManager) : base(logger, database, configManager)
        {
        }

        public override void Route(string[] args)
        {
            Parser.Default.ParseArguments<DatabaseCreate>(args)
                .MapResult(
                    o =>
                    {
                        CreateDb(o.ServerInstance, o.DatabaseName);
                        return 0;
                    },
                    errs =>
                    {
                        Logger.Log("Please create a database first.");
                        return 1;
                    }
                );
            return;
        }
    }
}
