using System;
using NHibernate;

using Configuration = NHibernate.Cfg.Configuration;

namespace UsersServer.Database
{
    // Klasa kontrolująca sesję nHibernate.
    public class SessionManager : ISessionManager
    {
        private readonly ISessionFactory _sessionFactory;
        public SessionManager(Configuration configuration)
        {
            _sessionFactory = configuration.BuildSessionFactory();
        }

        public ISession OpenSession()
        {
            return _sessionFactory.OpenSession();
        }

        public void CloseSession(ISession session)
        {
            session.Close();
        }
    }
}
