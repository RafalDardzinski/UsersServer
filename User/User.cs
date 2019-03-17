using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersServer.Database;

namespace UsersServer.User
{
    public class User
    {
        private static UserRepository repository = new UserRepository(new MsSqlDatabaseManager(AppConfigManager.GetConnectionString()));

        public static void Create(string firstname, string lastname, string username, string password)
        {
            var user = new UserModel
            {
                FirstName = firstname,
                LastName = lastname,
                Username = username,
                Password = password
            };
            repository.Create(user);
        }

        public static IList<UserModel> Read(int id, string firstname = null, string lastname = null, string username = null)
        {
            return repository.Read(id, firstname, lastname, username);
        }

        public static void Update(int id, string newFirstName = null, string newLastName = null, string newUsername = null, string newPassword = null)
        {
            var user = Read(id).FirstOrDefault();
            repository.Update(user, newFirstName, newLastName, newUsername, newPassword);
        }

        public static void Delete(int id)
        {
            var user = Read(id).FirstOrDefault();
            repository.Delete(user);
        }


    }

}
