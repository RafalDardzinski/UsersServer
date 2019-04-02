using System;
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
            using (var tx = Session.BeginTransaction())
            {
                user.Groups.Add(group);
                Session.Update(user);
                tx.Commit();
            }
        }

        // Usuń użytkownika z grupy.
        public void RemoveFromGroup(UserModel user, GroupModel group)
        {
            using (var tx = Session.BeginTransaction())
            {
                user.Groups.Remove(group);
                Session.Update(user);
                tx.Commit();
            }
        }
    }
}
