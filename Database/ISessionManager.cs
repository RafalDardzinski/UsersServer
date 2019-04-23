using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

		// Review: this method doesn't give us any added value
		/// <summary>
		/// Closes a NHibernate session.
		/// </summary>
		/// <param name="session">NHibernate session</param>
		void CloseSession();

	}
}
