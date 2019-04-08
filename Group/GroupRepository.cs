using NHibernate;
using UsersServer.Repository;

namespace UsersServer.Group
{
    public class GroupRepository : Repository<GroupModel>, IGroupRepository
    {
        public GroupRepository(ISession session) : base(session)
        {
        }

    }
}
