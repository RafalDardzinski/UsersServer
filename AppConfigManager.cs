using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersServer.Util
{
    // Pozwala na zarządzanie konfiguracją aplikacji.
    public class AppConfigManager
    {
        // Zapisuje connection string aby nie było potrzebne precyzowanie go podczas operacji na danych.
        public static void SetConnectionString(string connectionString)
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var connectionStringsSection = (ConnectionStringsSection)config.GetSection("connectionStrings");
            connectionStringsSection.ConnectionStrings["AppDatabase"].ConnectionString = connectionString;
            config.Save();
        }

        // Pobiera connection string.
        public static string GetConnectionString() => ConfigurationManager.ConnectionStrings["AppDatabase"].ConnectionString;
    }
}
