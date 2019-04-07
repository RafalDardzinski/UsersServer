using System;
using UsersServer.AppConfig;
using UsersServer.CLI;
using UsersServer.Database;
using UsersServer.ErrorHandler;
using UsersServer.Logger;

namespace UsersServer.Factory
{
    class CoreFactory : ICoreFactory
    {
        public IConfigManager CreateConfigManager()
        {
            return new LocalConfigManager(CreateLogger());
        }

        public IDatabase CreateDatabase()
        {
            return new MsSqlDatabase.MsSqlDatabase();
        }

        public ILogger CreateLogger()
        {
            return new Logger.ConsoleLogger();
        }

        public IServiceFactory CreateServiceFactory()
        {
            return new ServiceFactory();
        }

        public ICommandLineRouter CreateRouter()
        {
            var logger = CreateLogger();
            var database = CreateDatabase();
            var configManager = CreateConfigManager();
            if (String.IsNullOrEmpty(configManager.GetConnectionString().Database))
            {
                return new LimitedRouter(logger, database, configManager);
            }

            var serviceFactory = CreateServiceFactory();
            return new FullRouter(logger, database, configManager, serviceFactory);
        }

        public IErrorHandler CreateErrorHandler()
        {
            return new ErrorHandler.ErrorHandler(CreateLogger());
        }

    }
}
