using UsersServer.Database;

namespace UsersServer.AppConfig
{
    public interface IConfigManager
    {
        ConnectionStringData GetConnectionString();
        void SetConnectionString(IConnectionString connectionString);
    }
}