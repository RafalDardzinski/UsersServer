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

        public static IDatabase GetDatabase(string serverInstance)
        {
            var db = new MsSqlDatabase.MsSqlDatabase();
            db.Connect(serverInstance);
            return db;
        }
    }
}
