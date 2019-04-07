using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersServer.AppConfig;

namespace UsersServer.Database
{
    /// <summary>
    /// Data Access interface.
    /// </summary>
    public interface IDatabase
    {
        /// <summary>
        /// Session Manager.
        /// </summary>
        ISessionManager Session { get; }

        /// <summary>
        /// Database Manager.
        /// </summary>
        IDatabaseManager Manager { get; }

        /// <summary>
        /// Connects to the database and establishes SessionManager.
        /// </summary>
        /// <param name="serverInstance">server\instance to connect to <example>localhost\SQLEXPRESS</example></param>
        void Connect(string serverInstance);

        /// <summary>
        /// Connects to the database and establishes SessionManager using IConnectionString.
        /// </summary>
        /// <param name="connectionString">Connection string to the database.</param>
        void Connect(IConnectionString connectionString);

        /// <summary>
        /// Connects to the database using connection string stored in app configuration.
        /// </summary>
        /// <param name="configManager">Allows retrieving values from app configuration.</param>
        void Connect(IConfigManager configManager);

    }
}
