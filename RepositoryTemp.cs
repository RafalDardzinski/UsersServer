﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersServer.Database;

namespace UsersServer
{
    public abstract class RepositoryTemp
    {
        public delegate void RepositoryCommand(NHibernate.ISession session);

        protected readonly IDatabaseManager DatabaseManager;
        protected RepositoryTemp(IDatabaseManager databaseManager)
        {
            DatabaseManager = databaseManager;
        }
    }
}