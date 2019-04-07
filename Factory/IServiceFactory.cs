using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using UsersServer.Group;
using UsersServer.User;

namespace UsersServer.Factory
{
    public interface IServiceFactory
    {
        IUserService CreateUserService(ISession session);
        IGroupService CreateGroupService(ISession session);
    }
}
