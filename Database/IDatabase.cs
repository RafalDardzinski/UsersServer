using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersServer.Database
{
    /// <summary>
    /// Data Access interface.
    /// </summary>
    public interface IDatabase
    {
        /// <summary>
        /// Session Manager.
        /// </summary>
        ISessionManager Session { get; }

        /// <summary>
        /// Database Manager.
        /// </summary>
        IDatabaseManager Manager { get; }

        void Connect(string connectionString);
        void Connect(IConnectionString connectionString);
        void Connect();
    }
}
