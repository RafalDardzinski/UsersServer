using NHibernate;
using UsersServer.Group;
using UsersServer.User;

namespace UsersServer.Factory
{
    public class ServiceFactory : IServiceFactory
    {
        public IGroupService CreateGroupService(ISession session)
        {
            return new GroupService(session);
        }

        public IUserService CreateUserService(ISession session)
        {
            return new UserService(session);
        }
    }
}
