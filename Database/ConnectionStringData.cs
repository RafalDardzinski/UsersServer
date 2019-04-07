using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersServer.Database
{
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
