using NHibernate;

using Configuration = NHibernate.Cfg.Configuration;

namespace UsersServer.Database
{
    /// <summary>
    /// NHibernate session manager.
    /// </summary>
    public class SessionManager : ISessionManager
    {
        private readonly ISessionFactory _sessionFactory;

        /// <summary>
        /// Creates a new session manager.
        /// </summary>
        /// <param name="configuration">NHibernate configuration.</param>
        public SessionManager(Configuration configuration)
        {
            _sessionFactory = configuration.BuildSessionFactory();
        }

        /// <summary>
        /// Opens a new session.
        /// </summary>
        /// <returns>NHibernate database session.</returns>
        public ISession OpenSession()
        {
            return _sessionFactory.OpenSession();
        }
    }
}
