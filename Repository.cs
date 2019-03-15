using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersServer.Database;

namespace UsersServer
{
    public abstract class Repository
    {
        public delegate void RepositoryCommand(NHibernate.ISession session);
        protected readonly IDatabaseManager _databaseManager;
        protected Repository(IDatabaseManager databaseManager)
        {
            _databaseManager = databaseManager;
        }
    }
}
