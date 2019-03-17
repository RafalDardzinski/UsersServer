using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersServer.Group;
using UsersServer.User;

namespace UsersServer
{
    // Klasa "konsumująca" dane i wyświetlająca je na ekranie.
    class DataDisplayer
    {
        public static void Display(IList<UserModel> users)
        {
            string displayText = "";
            foreach (var user in users)
            {
                displayText += $"Id: {user.Id}\nUsername: {user.Username}\nFirstName: {user.FirstName}\nLastName: {user.LastName}\n\n";
            }
            Logger.Log(displayText);
        }
    }
}
