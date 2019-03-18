using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Tool.hbm2ddl;
using UsersServer.User;

namespace UsersServer.Database
{
    // 
    public class MsSqlDatabaseManager : IDatabaseManager
    {
        private readonly SessionManager _sessionManager;
        private readonly Configuration _configuration;
        private readonly HbmMapping _models;

        public MsSqlDatabaseManager(MsSqlConnectionString connectionString)
        {
            _models = MappingCompiler.CompileModels();
            _configuration = new MsSqlConfiguration(connectionString, _models);
            _sessionManager = new SessionManager(_configuration);
        }

        public MsSqlDatabaseManager(SessionManager sessionManager, Configuration configuration)
        {
            _models = MappingCompiler.CompileModels();
            _sessionManager = sessionManager;
            _configuration = configuration;
        }

        // Ustawia schemat bazy danych.
        public void SetupSchema()
        {
            new SchemaExport(_configuration).Create(false, true);
        }

        // Wykonuje operację udostępnioną przez repozytorium. Po wykonaniu polecenia zamyka sesję.
        public void Execute(RepositoryCommand repositoryCommand)
        {
            using (var session = _sessionManager.Open())
            using (var tx = session.BeginTransaction())
            {
                repositoryCommand(session);
                tx.Commit();
            }
        }

        public void Execute(RepositoryTemp.RepositoryCommand repositoryCommand)
        {
            using (var session = _sessionManager.Open())
            using (var tx = session.BeginTransaction())
            {
                repositoryCommand(session);
                tx.Commit();
            }
        }

        // Umożliwia wykonanie kodu SQL na bazie danych. Po wykonaniu polecenia zamyka sesję.
        private void Execute(string dbCommandText)
        {
            using (var session = _sessionManager.Open())
            using (var command = session.Connection.CreateCommand())
            {
                command.CommandText = dbCommandText;
                command.ExecuteNonQuery();
            }
        }

        // Tworzy nową bazę danych, zwraca connection string do nowej bazy danych.
        public static void Create(string serverInstance, string dbName)
        {
            // Create database
            var connectionString = new MsSqlConnectionString(serverInstance);
            var dbManager = new MsSqlDatabaseManager(connectionString);
            dbManager.Execute($@"create database [{dbName}]"); // wiem że to się aż prosi o SQL Injection, ale nHibernate nie udostępnia paramterów dla DDL, a to polecenie będzie dostępne tylko z poziomu CLI...

            // Upload schema
            var newDatabaseConnectionString = new MsSqlConnectionString(serverInstance, dbName);
            new MsSqlDatabaseManager(newDatabaseConnectionString).SetupSchema();
            Logger.Log($"Database {dbName} created successfully.");
            AppConfigManager.SetConnectionString(newDatabaseConnectionString);
        }
    }
}
