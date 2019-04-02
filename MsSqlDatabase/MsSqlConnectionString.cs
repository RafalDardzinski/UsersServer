using System;

namespace UsersServer.Database
{
    /// <summary>
    /// Creates connection string for MSSQL database.
    /// </summary>
    public class MsSqlConnectionString : IConnectionString
    {
        private const string ConnectionStringBase = @"Integrated Security=true;"; // integrated security for simplicity
        public string ServerInstance { get; }
        public string Database { get; }

        public string Value
        {
            get
            {
                if (String.IsNullOrWhiteSpace(ServerInstance))
                    return null;
                var connectionString = String.Copy(ConnectionStringBase);
                connectionString += $@"Server={ServerInstance};";
                if (!String.IsNullOrWhiteSpace(Database))
                    connectionString += $@"Database={Database};";
                return connectionString;
            }
        }

        /// <summary>
        /// Creates connection string to a server.
        /// </summary>
        /// <param name="serverInstance">server\instance to connect to <example>localhost\SQLEXPRESS</example></param>
        public MsSqlConnectionString(string serverInstance)
        {
            ServerInstance = serverInstance;
        }

        /// <summary>
        /// Creates connection string to a server.
        /// </summary>
        /// <param name="serverInstance">server\instance to connect to <example>localhost\SQLEXPRESS</example></param>
        /// <param name="databaseName">Database to connect to.</param>
        public MsSqlConnectionString(string serverInstance, string databaseName)
            : this(serverInstance)
        {
            Database = databaseName;
        }
    }
}
