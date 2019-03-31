﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;

namespace UsersServer.Database
{
    public interface IDatabaseManager
    {
        IConnectionString Create(ISession session, string serverName, string dbName);
    }
}
