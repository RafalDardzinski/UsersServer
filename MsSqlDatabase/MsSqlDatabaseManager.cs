using NHibernate;
using NHibernate.Tool.hbm2ddl;
using UsersServer.Database;

namespace UsersServer.MsSqlDatabase
{
    class MsSqlDatabaseManager : IDatabaseManager
    {
        public IConnectionString Create(ISession session, string serverInstance, string dbName)
        {
            var command = session.Connection.CreateCommand();
            command.CommandText = $@"create database [{dbName}]";
            command.ExecuteNonQuery();
            var connectionString = new MsSqlConnectionString(serverInstance, dbName);
            var config = new MsSqlConfiguration(connectionString);
            new SchemaExport(config).Create(false, true);
            return connectionString;
        }
    }
}
