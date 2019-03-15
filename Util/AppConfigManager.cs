using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersServer.Util
{
    public class AppConfigManager
    {
        public static void SetConnectionString(string connectionString)
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var connectionStringsSection = (ConnectionStringsSection)config.GetSection("connectionStrings");
            connectionStringsSection.ConnectionStrings["AppDatabase"].ConnectionString = connectionString;
            config.Save();
        }

        public static string GetConnectionString() => ConfigurationManager.ConnectionStrings["AppDatabase"].ConnectionString;
    }
}
