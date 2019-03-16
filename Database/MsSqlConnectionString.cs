﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersServer.Database
{
    // Tworzy connection string dla bazy MSSQL.
    public class MsSqlConnectionString
    {
        private readonly string _connectionStringBase = @"Integrated Security=true;"; // dla uproszczenia tylko integrated security
        private readonly string _serverInstance;
        private readonly string _databaseName;

        public string Value
        {
            get
            {
                var connectionString = String.Copy(_connectionStringBase);
                if (!String.IsNullOrWhiteSpace(_serverInstance))
                    connectionString += $@"Server={_serverInstance};";
                if (!String.IsNullOrWhiteSpace(_databaseName))
                    connectionString += $@"Database={_databaseName};";
                return connectionString;
            }
            private set => Value = value;
        }

        public MsSqlConnectionString(string serverInstance)
        {
            _serverInstance = serverInstance;
        }

        public MsSqlConnectionString(string serverInstance, string databaseName)
            : this(serverInstance)
        {
            _databaseName = databaseName;
        }
    }
}
