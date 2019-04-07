using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using UsersServer.AppConfig;
using UsersServer.CLI;
using UsersServer.Database;
using UsersServer.Logger;
using UsersServer.User;

namespace UsersServer.Factory
{
    public interface ICoreFactory
    {
        IConfigManager CreateConfigManager();
        IDatabase CreateDatabase();
        ILogger CreateLogger();
        ICommandLineRouter CreateRouter();
    }
}
