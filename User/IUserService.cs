using System.Collections.Generic;
using UsersServer.Group;

namespace UsersServer.User
{
    public interface IUserService
    {
        void Create(string firstname, string lastname, string username, string password);

        IList<UserModel> Read(int id = 0, string firstname = null, string lastname = null, string username = null);

        void Update(int id, string newFirstName = null, string newLastName = null, string newUsername = null, string newPassword = null);

        void AddToGroup(int userId, GroupModel group);

        void RemoveFromGroup(int userId, GroupModel group);

        void Delete(int id);
    }
}
