using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersServer.Database
{
    class MsSqlDatabaseManager : IDatabaseManager
    {
        private readonly IDatabaseSessionManager _sessionManager;

        public MsSqlDatabaseManager(IDatabaseSessionManager sessionManager)
        {
            _sessionManager = sessionManager;
            

        }

        public void CreateDatabase(string databaseName)
        {
            Console.WriteLine("Database created: {0}", databaseName);
        }
    }
}
