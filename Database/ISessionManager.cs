using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;

namespace UsersServer.Database
{
    public interface ISessionManager
    {
        ISession OpenSession();
        void CloseSession(ISession session);
    }
}
