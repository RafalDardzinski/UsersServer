using System;
using UsersServer.Database;

namespace UsersServer.Database
{
    // Tworzy connection string dla bazy MSSQL.
    public class MsSqlConnectionString : IConnectionString
    {
        private readonly string _connectionStringBase = @"Integrated Security=true;"; // dla uproszczenia tylko integrated security
        private readonly string _serverInstance;
        private readonly string _databaseName;

        public string Value
        {
            get
            {
                if (String.IsNullOrWhiteSpace(_serverInstance))
                    return null;
                var connectionString = String.Copy(_connectionStringBase);
                connectionString += $@"Server={_serverInstance};";

                if (!String.IsNullOrWhiteSpace(_databaseName))
                    connectionString += $@"Database={_databaseName};";
                return connectionString;
            }
        }

        public MsSqlConnectionString(string serverInstance)
        {
            _serverInstance = serverInstance;
        }

        public MsSqlConnectionString(string serverInstance, string databaseName)
            : this(serverInstance)
        {
            _databaseName = databaseName;
        }
    }
}
