using UsersServer.AppConfig;
using UsersServer.Database;
using UsersServer.Logger;

namespace UsersServer.CLI
{
    /// <summary>
    /// Contains core implementation of the application router.
    /// </summary>
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

        /// <summary>
        /// Executes appplication based on user's input.
        /// </summary>
        /// <param name="args">Parameters provided by the user.</param>
        public abstract void Route(string[] args);

        // Zastanawiałem się czy ta metoda powinna się tu znaleźć, ale jest ona współdzielona zarówno dla LimitedRoutera jak i FullRoutera. 
        /// <summary>
        /// Creates a database and saves a connection string to it in the configuration.
        /// </summary>
        /// <param name="serverInstance">server\instance string <example>localhost\SQLEXPRESS</example>></param>
        /// <param name="dbName">Name of the database.</param>
        protected void CreateDb(string serverInstance, string dbName)
        {
            Database.Connect(serverInstance);
            IConnectionString connectionString;
            using (var session = Database.Session.OpenSession())
            {
                connectionString = Database.Manager.Create(session, serverInstance, dbName);
            }

            ConfigManager.SetConnectionString(connectionString);
            Logger.Log($"{dbName} created successfully!");
        }
    }
}
