using System;
using System.Linq;
using NHibernate;
using UsersServer.Group;
using UsersServer.Repository;

namespace UsersServer.User
{
    // Repozytorium dla użytkowników wykorzystuje standardowe metody Repozytorium ale też zawiera własne.
    class UserRepository : Repository<UserModel>
    {

        public UserRepository(ISession session) : base(session)
        {
        }

        // Dodaj użytkownika do grupy. 
        public void AddToGroup(UserModel user, GroupModel group)
        {
            if (user.Groups.Contains(group))
            {
                throw new InvalidOperationException("User is already a group member");
            }
            user.Groups.Add(group);
            Update(user);
        }

        // Usuń użytkownika z grupy.
        public void RemoveFromGroup(UserModel user, GroupModel group)
        {
            user.Groups.Remove(group);
            Update(user);
        }
    }
}
