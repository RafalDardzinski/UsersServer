using UsersServer.AppConfig;
using UsersServer.Database;
using UsersServer.Logger;

namespace UsersServer.CLI
{
    abstract class Router : ICommandLineRouter
    {
        protected readonly ILogger Logger;
        protected readonly IDatabase Database;
        protected readonly IConfigManager ConfigManager;

        public Router(ILogger logger, IDatabase database, IConfigManager configManager)
        {
            Logger = logger;
            Database = database;
            ConfigManager = configManager;
        }

        public abstract void Route(string[] args);

        protected void CreateDb(string serverInstance, string dbName)
        {
            Database.Connect(serverInstance);
            var session = Database.Session.OpenSession();
            var connectionString = Database.Manager.Create(session, serverInstance, dbName);
            Database.Session.CloseSession();

            ConfigManager.SetConnectionString(connectionString);
            Logger.Log($"{dbName} created successfully!");
        }
    }
}
