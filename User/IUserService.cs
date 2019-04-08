using System.Collections.Generic;
using UsersServer.Group;

namespace UsersServer.User
{
    /// <summary>
    /// Provides methods to manage users.
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Creates a new user in the database.
        /// </summary>
        /// <param name="firstname"></param>
        /// <param name="lastname"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        void Create(string firstname, string lastname, string username, string password);

        /// <summary>
        /// Searches for the user based on provided criteria.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="firstname"></param>
        /// <param name="lastname"></param>
        /// <param name="username"></param>
        /// <returns></returns>
        IList<UserModel> Read(int id = 0, string firstname = null, string lastname = null, string username = null);

        /// <summary>
        /// Updates a user.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="newFirstName"></param>
        /// <param name="newLastName"></param>
        /// <param name="newUsername"></param>
        /// <param name="newPassword"></param>
        void Update(int id, string newFirstName = null, string newLastName = null, string newUsername = null, string newPassword = null);

        /// <summary>
        /// Adds user to the group.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="group">Group instance fetched from a database.</param>
        void AddToGroup(int userId, GroupModel group);

        void RemoveFromGroup(int userId, GroupModel group);

        void Delete(int id);
    }
}
