using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Cfg;

namespace UsersServer.Database
{
    public class MsSqlDatabaseManager
    {
        private readonly SessionManager _sessionManager;
        private readonly Configuration _configuration;
        public MsSqlDatabaseManager(SessionManager sessionManager, Configuration configuration)
        {
            _sessionManager = sessionManager;
            _configuration = configuration;
        }

        public static void Init(string connectionString, out SessionManager sessionManager)
        {
            // inicjalizacja zależności - SessionManager
            var models = MappingCompiler.CompileModels();
            var configuration = new MsSqlConfiguration(connectionString, models);
            sessionManager = new SessionManager(configuration);
        }

        public static void Init(string connectionString, out SessionManager sessionManager, out Configuration configuration)
        {
            // inicjalizacja zależności SessionManager oraz Configuration
            var models = MappingCompiler.CompileModels();
            configuration = new MsSqlConfiguration(connectionString, models);
            sessionManager = new SessionManager(configuration);
        }

        public static string Create(string serverInstance, string dbName)
        {
            // tworzy nową bazę danych
            var connectionString = $@"Server={serverInstance};Integrated Security=true;";
            Init(connectionString, out var sessionManager);

            using (var session = sessionManager.Open())
            using (var command = session.Connection.CreateCommand())
            {
                // teoretycznie to powinno być zsanityzowane, ale dostęp do tej metody będzie miała osoba ustawiająca bazę danych, więc zakładam że nie będzie zainteresowana SQL injection :)
                command.CommandText = $@"create database [{dbName}]";
                command.ExecuteNonQuery();
            }

            return connectionString + $"Database={dbName};";
        }


    }
}
