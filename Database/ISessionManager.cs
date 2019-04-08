using NHibernate;

namespace UsersServer.Database
{
	/// <summary>
	/// Allows NHibernate session management.
	/// </summary>
	public interface ISessionManager
	{
		/// <summary>
		/// Opens a new NHibernate session.
		/// </summary>
		/// <returns>NHibernate session.</returns>
		ISession OpenSession();
	}
}
