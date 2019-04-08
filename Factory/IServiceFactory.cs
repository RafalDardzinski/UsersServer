using NHibernate;
using UsersServer.Group;
using UsersServer.User;

namespace UsersServer.Factory
{
    /// <summary>
    /// Provides methods to create services.
    /// </summary>
    public interface IServiceFactory
    {
        IUserService CreateUserService(ISession session);
        IGroupService CreateGroupService(ISession session);
    }
}
