using NHibernate;
using UsersServer.Database;
using UsersServer.Repository;

namespace UsersServer.Group
{
    // Repozytorium dla grupy implementuje standardowe funkcjonalności Repozytorium.
    public class GroupRepository : Repository<GroupModel>, IGroupRepository
    {
        public GroupRepository(ISession session) : base(session)
        {
        }

    }
}
