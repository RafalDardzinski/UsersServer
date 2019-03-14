using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Cfg;
using Configuration = NHibernate.Cfg.Configuration;

namespace UsersServer.Database
{
    public class SessionManager
    {
        private readonly ISessionFactory _sessionFactory;
        public SessionManager(Configuration configuration)
        {
            _sessionFactory = configuration.BuildSessionFactory();
        }

        public ISession Open()
        {
            return _sessionFactory.OpenSession();
        }

        public void Close(ISession session)
        {
            session.Close();
        }
    }
}
