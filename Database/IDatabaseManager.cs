using NHibernate;

namespace UsersServer.Database
{
    /// <summary>
    /// Provides tools to manage a database.
    /// </summary>
    public interface IDatabaseManager
    {
        /// <summary>
        /// Creates a new database. 
        /// </summary>
        /// <param name="session">NHibernate session.</param>
        /// <param name="serverInstance">server\instance where database is to be created. <example>localhost\SQLEXPRESS</example></param>
        /// <param name="dbName">Name of the database to create.</param>
        /// <returns>Connection string to the created database.</returns>
        IConnectionString Create(ISession session, string serverInstance, string dbName);
    }
}
