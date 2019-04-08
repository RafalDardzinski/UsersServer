namespace UsersServer.Database
{
    /// <summary>
    /// Contains data needed for connection string.
    /// </summary>
    public class ConnectionStringData
    {
        public string ServerInstance { get; }
        public string Database { get; }


        public ConnectionStringData(string serverInstance)
        {
            ServerInstance = serverInstance;
        }

        public ConnectionStringData(string serverInstance, string database) : this(serverInstance)
        {
            Database = database;
        }

    }
}
