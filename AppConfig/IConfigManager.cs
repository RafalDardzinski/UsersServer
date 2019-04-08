using UsersServer.Database;

namespace UsersServer.AppConfig
{
    /// <summary>
    /// Provides methods to manage the application configuration storage.
    /// </summary>
    public interface IConfigManager
    {
        /// <summary>
        /// Get connection string data from the configuration storage.
        /// </summary>
        /// <returns>Contains information about the server/instance and the database name.</returns>
        ConnectionStringData GetConnectionString();

        /// <summary>
        /// Save the ConnectionString in the configuration storage.
        /// </summary>
        /// <param name="connectionString">Contains information about server/instance and the database name.</param>
        void SetConnectionString(IConnectionString connectionString);
    }
}