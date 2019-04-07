using System;
using System.Collections.Generic;
using System.Linq;
using UsersServer.Group;
using UsersServer.User;

namespace UsersServer.Logger
{
    public class ConsoleLogger : ILogger
    {
        public ConsoleLogger()
        {
        }

        public void Log(string message)
        {
            Console.WriteLine(message);
        }

        public void Log(IList<UserModel> users)
        {
            var displayText = "";
            foreach (var user in users)
            {
                var groups = GetGroupNames(user);
                displayText += $"\nId: {user.UserId}\nUsername: {user.Username}\nFirstName: {user.FirstName}\nLastName: {user.LastName}\nGroups: {groups}\n";
            }
            Log(displayText);

            // Lokalna metoda agregująca nazwy group do których należy użytkownik i zamieniająca je na ciąg znaków.
            string GetGroupNames(UserModel user)
            {
                var groupNames = user.Groups.Select(g => g.Name);
                return String.Join(", ", groupNames);
            }
        }

        public void Log(IList<GroupModel> groups)
        {
            var displayText = "";
            foreach (var group in groups)
            {
                displayText += $"\nId: {group.GroupId}\nName: {group.Name}\n";
            }
            Log(displayText);
        }
    }
}
