using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersServer.Database;

namespace UsersServer
{
    public class DatabaseService
    {
        public static IDatabase GetDatabase()
        {
            var db = new MsSqlDatabase.MsSqlDatabase();
            db.Connect();
            return db;
        }
    }
}
