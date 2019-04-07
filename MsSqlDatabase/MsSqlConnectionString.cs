using System;

namespace UsersServer.Database
{
    /// <summary>
    /// Creates connection string for MSSQL database.
    /// </summary>
    public class MsSqlConnectionString : ConnectionStringData, IConnectionString
    {
        private const string ConnectionStringBase = @"Integrated Security=true;"; // integrated security for simplicity

        public MsSqlConnectionString(string serverInstance) : base(serverInstance)
        {
        }

        public MsSqlConnectionString(string serverInstance, string database) : base(serverInstance, database)
        {
        }

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
    }
}
