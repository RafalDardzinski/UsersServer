using System.Collections.Generic;
using UsersServer.Group;
using UsersServer.User;

namespace UsersServer.Logger
{
    public interface ILogger
    {
        void Log(string message);
        void Log(IList<UserModel> users);
        void Log(IList<GroupModel> groups);
    }
}