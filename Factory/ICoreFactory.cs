using UsersServer.AppConfig;
using UsersServer.CLI;
using UsersServer.Database;
using UsersServer.Logger;

namespace UsersServer.Factory
{
    /// <summary>
    /// Provides methods to create core components of the application.
    /// </summary>
    public interface ICoreFactory
    {
        IConfigManager CreateConfigManager();
        IDatabase CreateDatabase();
        ILogger CreateLogger();
        ICommandLineRouter CreateRouter();
    }
}
