using System;
using System.Linq;
using UsersServer.Database;
using UsersServer.Group;

namespace UsersServer.User
{
    // Repozytorium dla użytkowników wykorzystuje standardowe metody Repozytorium ale też zawiera własne.
    class UserRepository : Repository<UserModel>
    {
        private int _addToGroupUserId;
        private int _addToGroupGroupId;
        private int _removeFromGroupUserId;
        private int _removeFromGroupGroupId;
        public UserRepository(MsSqlDatabaseManager databaseManager) : base(databaseManager)
        {
        }

        // Dodaj użytkownika do grupy. 
        public void AddToGroup(int userId, int groupId)
        {
            _addToGroupUserId = userId;
            _addToGroupGroupId = groupId;

            RepositoryCommand cmd = _AddToGroup;
            DatabaseManager.Execute(cmd);
        }

        private void _AddToGroup(NHibernate.ISession session)
        {
            var user = session.QueryOver<UserModel>().Where(u => u.UserId == _addToGroupUserId).List().FirstOrDefault();
            if (user == null)
                throw new InvalidOperationException($"User (UserId: {_addToGroupUserId}) does not exist.");

            var group = session.QueryOver<GroupModel>().Where(g => g.GroupId == _addToGroupGroupId).List().FirstOrDefault();
            if (group == null)
                throw new InvalidOperationException($"Group (GroupId: {_addToGroupGroupId}) does not exist.");

            // Zgłoś błąd jeśli użytkownik jest już przypisany do tej grupy.
            if (user.Groups.Contains(group))
            {
                throw new InvalidOperationException($"User is already in a group: {group.Name}");
            }
            user.Groups.Add(group);
            session.Update(user);
        }

        // Usuń użytkownika z grupy.
        public void RemoveFromGroup(int userId, int groupId)
        {
            _removeFromGroupUserId = userId;
            _removeFromGroupGroupId = groupId;

            RepositoryCommand cmd = _RemoveFromGroup;
            DatabaseManager.Execute(cmd);
        }

        private void _RemoveFromGroup(NHibernate.ISession session)
        {
            var user = session.QueryOver<UserModel>().Where(u => u.UserId == _removeFromGroupUserId).List().FirstOrDefault();
            if (user == null)
                throw new InvalidOperationException($"User (UserId: {_removeFromGroupUserId}) does not exist.");

            var group = session.QueryOver<GroupModel>().Where(g => g.GroupId == _removeFromGroupGroupId).List().FirstOrDefault();
            if (group == null)
                throw new InvalidOperationException($"Group (GroupId: {_removeFromGroupGroupId}) does not exist.");

            // Zgłoś błąd jeśli użytkownik nie jest przypisany do grupy z której próbujesz go usunąć.
            if (!user.Groups.Contains(group))
            {
                throw new InvalidOperationException($"User is not in a group: {group.Name}");
            }

            user.Groups.Remove(group);
            session.Update(user);
        }
    }
}
