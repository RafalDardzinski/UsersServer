using System;
using System.Collections.Generic;
using System.Linq;
using UsersServer.Group;
using UsersServer.User;

namespace UsersServer
{
    // Klasa "konsumująca" dane i wyświetlająca je na ekranie.
    class DataDisplayer
    {
        public static void Display(IList<UserModel> users)
        {
            var displayText = "";
            foreach (var user in users)
            {
                var groups = GetGroupNames(user);
                displayText += $"\nId: {user.UserId}\nUsername: {user.Username}\nFirstName: {user.FirstName}\nLastName: {user.LastName}\nGroups: {groups}\n";
            }
            Logger.Log(displayText);

            // Lokalna metoda agregująca nazwy group do których należy użytkownik i zamieniająca je na ciąg znaków.
            string GetGroupNames(UserModel user)
            {
                var groupNames = user.Groups.Select(g => g.Name);
                return String.Join(", ", groupNames);
            } 
        }

        public static void Display(IList<GroupModel> groups)
        {
            var displayText = "";
            foreach (var group in groups)
            {
                displayText += $"\nId: {group.GroupId}\nName: {group.Name}\n";
            }
            Logger.Log(displayText);
        }
    }
}
