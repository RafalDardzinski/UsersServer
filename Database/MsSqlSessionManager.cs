using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Cfg;

namespace UsersServer.Database
{
    class MsSqlSessionManager : IDatabaseSessionManager
    {
        public ISession Session { get; private set; }
        private readonly ISessionFactory _sessionFactory;

        public MsSqlSessionManager(Configuration configuration)
        {
            _sessionFactory = configuration.BuildSessionFactory();
        }

        public void Open()
        {
            Session = _sessionFactory.OpenSession();
            
        }

        public void Close()
        {
            Session.Close();
        }
    }
}
