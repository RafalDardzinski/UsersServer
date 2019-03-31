using System.Configuration;
using System.Data.SqlClient;
using UsersServer.Database;
using static System.Configuration.ConfigurationManager;

namespace UsersServer
{
    // Pozwala na zarządzanie konfiguracją aplikacji.
    public class AppConfigManager
    {
        // Zapisuje connection string aby nie było potrzebne precyzowanie go podczas operacji na danych.
        public static void SetConnectionString(IConnectionString connectionString)
        {
            var config = OpenExeConfiguration(ConfigurationUserLevel.None);
            var connectionStringsSection = (ConnectionStringsSection)config.GetSection("connectionStrings");
            connectionStringsSection.ConnectionStrings["AppDatabase"].ConnectionString = connectionString.Value;
            config.Save();
            Logger.Log($"{connectionString.Value} is now setup as default connection string.");

        }

        // Pobiera connection string.
        public static IConnectionString GetConnectionString()
        {
            var connectionStringRaw = ConnectionStrings["AppDatabase"].ConnectionString;
            var builder = new SqlConnectionStringBuilder(connectionStringRaw);
            builder.TryGetValue("Server", out var server);
            builder.TryGetValue("Database", out var database);
            return new MsSqlConnectionString(server.ToString(), database.ToString());
        }
    }
}
