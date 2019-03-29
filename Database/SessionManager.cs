using System;
using NHibernate;
using Configuration = NHibernate.Cfg.Configuration;

namespace UsersServer.Database
{
    // Klasa kontrolująca sesję nHibernate.
    public class SessionManager
    {
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
    }
}