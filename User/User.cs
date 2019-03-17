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

        public static IList<UserModel> Read(int id, string firstname, string lastname, string username)
        {
            return repository.Read(id, firstname, lastname, username);
            
        }
    }

}
