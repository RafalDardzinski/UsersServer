using NHibernate;
using NHibernate.Context;
using Configuration = NHibernate.Cfg.Configuration;

namespace UsersServer.Database
{
    /// <summary>
    /// NHibernate session manager.
    /// </summary>
    public class SessionManager : ISessionManager
    {
        private readonly ISessionFactory _sessionFactory;

        private ISession _session;

        /// <summary>
        /// Creates a new session manager.
        /// </summary>
        /// <param name="configuration">NHibernate configuration.</param>
        public SessionManager(Configuration configuration)
        {
            _sessionFactory = configuration.BuildSessionFactory();
        }

        public ISession OpenSession()
        {
            _session = _sessionFactory.OpenSession();
            return _session;
        }

        public void CloseSession()
        {
            _session.Close();
        }
    }
}
