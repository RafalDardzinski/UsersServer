using NHibernate.Cfg;
using UsersServer.Database;

namespace UsersServer.MsSqlDatabase
{
    class MsSqlDatabase : IDatabase
    {
        public ISessionManager Session { get; private set; }
        public IDatabaseManager Manager { get; }

        public void Connect(IConnectionString connectionString)
        {
            var configuration = new MsSqlConfiguration(connectionString);
            Session = new SessionManager(configuration);
        }

        public void Connect(string serverInstance)
        {
            var connectionString = new MsSqlConnectionString(serverInstance);
            this.Connect(connectionString);
        }

        public void Connect()
        {
            this.Connect(AppConfigManager.GetConnectionString());
        }

        public MsSqlDatabase()
        {
            Manager = new MsSqlDatabaseManager();
        }
    }
}
