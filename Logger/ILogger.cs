using System.Collections.Generic;
using UsersServer.Group;
using UsersServer.User;

namespace UsersServer.Logger
{
    public interface ILogger
    {
        /// <summary>
        /// Logs a simple message.
        /// </summary>
        /// <param name="message"></param>
        void Log(string message);

        /// <summary>
        /// Displays list of users in a console.
        /// </summary>
        /// <param name="users">List of UserModel instances.</param>
        void Log(IList<UserModel> users);

        /// <summary>
        /// Displays list of groups in a console.
        /// </summary>
        /// <param name="groups">List of GroupModel instances.</param>
        void Log(IList<GroupModel> groups);
    }
}