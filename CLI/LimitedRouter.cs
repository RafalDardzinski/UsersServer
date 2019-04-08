using CommandLine;
using UsersServer.AppConfig;
using UsersServer.CLI.Options;
using UsersServer.Database;
using UsersServer.Logger;

namespace UsersServer.CLI
{
    /// <summary>
    /// Provides access to limited number of application's functionalities.
    /// </summary>
    class LimitedRouter : Router
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
