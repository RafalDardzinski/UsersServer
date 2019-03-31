using System;
using System.Linq;
using NHibernate;
using UsersServer.Database;
using UsersServer.Group;

namespace UsersServer.User
{
    // Repozytorium dla użytkowników wykorzystuje standardowe metody Repozytorium ale też zawiera własne.
    class UserRepository : Repository<UserModel>
    {

        public UserRepository(ISession session) : base(session)
        {
        }

        // Dodaj użytkownika do grupy. 
        public void AddToGroup(int userId, int groupId)
        {
            var user = _session.QueryOver<UserModel>().Where(u => u.UserId == userId).List().FirstOrDefault();
            if (user == null)
                throw new InvalidOperationException($"User (UserId: {userId}) does not exist.");

            var group = _session.QueryOver<GroupModel>().Where(g => g.GroupId == groupId).List().FirstOrDefault();
            if (group == null)
                throw new InvalidOperationException($"Group (GroupId: {groupId}) does not exist.");

            // Zgłoś błąd jeśli użytkownik jest już przypisany do tej grupy.
            if (user.Groups.Contains(group))
            {
                throw new InvalidOperationException($"User is already in a group: {group.Name}");
            }
            user.Groups.Add(group);
            _session.Update(user);
        }

        // Usuń użytkownika z grupy.
        public void RemoveFromGroup(int userId, int groupId)
        {

            var user = _session.QueryOver<UserModel>().Where(u => u.UserId == userId).List().FirstOrDefault();
            if (user == null)
                throw new InvalidOperationException($"User (UserId: {userId}) does not exist.");

            var group = _session.QueryOver<GroupModel>().Where(g => g.GroupId == groupId).List().FirstOrDefault();
            if (group == null)
                throw new InvalidOperationException($"Group (GroupId: {groupId}) does not exist.");

            // Zgłoś błąd jeśli użytkownik nie jest przypisany do grupy z której próbujesz go usunąć.
            if (!user.Groups.Contains(group))
            {
                throw new InvalidOperationException($"User is not in a group: {group.Name}");
            }

            user.Groups.Remove(group);
            _session.Update(user);
        }
    }
}
