using System.Configuration;
using System.Data.SqlClient;
using UsersServer.Database;
using UsersServer.Logger;
using static System.Configuration.ConfigurationManager;

namespace UsersServer.AppConfig
{
    /// <summary>
    /// Operates on local application configuration file.
    /// </summary>
    public class LocalConfigManager : IConfigManager
    {
        private ILogger _logger;

        public LocalConfigManager(ILogger logger)
        {
            _logger = logger;
        }

        public ConnectionStringData GetConnectionString()
        {
            var connectionStringRaw = ConnectionStrings["AppDatabase"].ConnectionString;
            var builder = new SqlConnectionStringBuilder(connectionStringRaw);
            builder.TryGetValue("Server", out var server);
            builder.TryGetValue("Database", out var database);
            return new ConnectionStringData(server.ToString(), database.ToString());
        }


        public void SetConnectionString(IConnectionString connectionString)
        {
            var config = OpenExeConfiguration(ConfigurationUserLevel.None);
            var connectionStringsSection = (ConnectionStringsSection)config.GetSection("connectionStrings");
            connectionStringsSection.ConnectionStrings["AppDatabase"].ConnectionString = connectionString.Value;
            config.Save();
            _logger.Log($"{connectionString.Value} is now setup as default connection string.");

        }
    }
}
