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
        // Manager sesji dla nHibernate. 
        private readonly ISessionFactory _sessionFactory;
        private ISession _session;
        public SessionManager(Configuration configuration)
        {
            _sessionFactory = configuration.BuildSessionFactory();
        }

        public ISession Open()
        {
            if (_session == null)
            {
                _session = _sessionFactory.OpenSession();
                return _session;
            }
            if (_session.IsOpen) throw new InvalidOperationException("Session is already open.");

            _session = _sessionFactory.OpenSession();
            return _session;
        }

        public void Close()
        {
            _session.Close();
        }
    }
}
