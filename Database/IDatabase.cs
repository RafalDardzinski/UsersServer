using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersServer.Database
{
    public interface IDatabase
    {
        ISessionManager Session { get; }
        IDatabaseManager Manager { get; }
        void Connect(string connectionString);
        void Connect(IConnectionString connectionString);
        void Connect();
    }
}
