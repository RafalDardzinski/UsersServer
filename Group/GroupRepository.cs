using NHibernate;
using UsersServer.Database;

namespace UsersServer.Group
{
    // Repozytorium dla grupy implementuje standardowe funkcjonalności Repozytorium.
    public class GroupRepository : Repository<GroupModel>
    {
        public GroupRepository(ISession session) : base(session)
        {
        }

    }
}
