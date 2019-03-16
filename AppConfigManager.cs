using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersServer.Database;
using static System.Configuration.ConfigurationManager;

namespace UsersServer
{
    // Pozwala na zarządzanie konfiguracją aplikacji.
    public class AppConfigManager
    {
        // Zapisuje connection string aby nie było potrzebne precyzowanie go podczas operacji na danych.
        public static void SetConnectionString(MsSqlConnectionString connectionString)
        {
            var config = OpenExeConfiguration(ConfigurationUserLevel.None);
            var connectionStringsSection = (ConnectionStringsSection)config.GetSection("connectionStrings");
            connectionStringsSection.ConnectionStrings["AppDatabase"].ConnectionString = connectionString.Value;
            config.Save();
            Logger.Log($"{connectionString.Value} is now setup as default connection string.");

        }

        // Pobiera connection string.
        public static string GetConnectionString() => ConnectionStrings["AppDatabase"].ConnectionString;
    }
}
