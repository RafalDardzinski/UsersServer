using System.Collections.Generic;

namespace UsersServer.User
{
    public interface IUserManager
    {
        void Create(string firstname, string lastname, string username, string password);

        IList<UserModel> Read(int id = 0, string firstname = null, string lastname = null, string username = null);

        void Update(int id, string newFirstName = null, string newLastName = null, string newUsername = null, string newPassword = null);

        void AddToGroup(int userId, int groupId);

        void RemoveFromGroup(int userId, int groupId);

        void Delete(int id);
    }
}
