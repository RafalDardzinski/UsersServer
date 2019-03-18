using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Criterion;
using UsersServer.Database;
using UsersServer.Group;

namespace UsersServer.User
{
    // Repozytorium użytkowników odpowiada za bezpośrednie operacje na bazie danych.
    // Każdej publicznej metodzie odpowiada także metoda prywatna która przekazywana jest do MsSqlDatabaseManager jako delegat a następnie wywoływana z instancją sesji jako argumentem.
    // Dzięki temu logika zapytań pozostaje w repozytorium, a zarządzaniem sesją i tranzakcjami zajmuje się DatabaseManager.
    class UserRepository : Repository<UserModel>
    {
        private int _addToGroupUserId;
        private int _addToGroupGroupId;
        public UserRepository(MsSqlDatabaseManager databaseManager) : base(databaseManager)
        {
        }

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

            if (user.Groups.Contains(group))
            {
                throw new InvalidOperationException($"User is already in a group: {group.Name}");
            }
            user.Groups.Add(group);
            session.Update(user);
        }

        public void RemoveFromGroup(int userId, int groupId)
        {
            _addToGroupUserId = userId;
            _addToGroupGroupId = groupId;

            RepositoryCommand cmd = _RemoveFromGroup;
            DatabaseManager.Execute(cmd);
        }

        private void _RemoveFromGroup(NHibernate.ISession session)
        {
            var user = session.QueryOver<UserModel>().Where(u => u.UserId == _addToGroupUserId).List().FirstOrDefault();
            if (user == null)
                throw new InvalidOperationException($"User (UserId: {_addToGroupUserId}) does not exist.");

            var group = session.QueryOver<GroupModel>().Where(g => g.GroupId == _addToGroupGroupId).List().FirstOrDefault();
            if (group == null)
                throw new InvalidOperationException($"Group (GroupId: {_addToGroupGroupId}) does not exist.");

            if (!user.Groups.Contains(group))
            {
                throw new InvalidOperationException($"User is not in a group: {group.Name}");
            }

            user.Groups.Remove(group);
            session.Update(user);
        }
    }
}
