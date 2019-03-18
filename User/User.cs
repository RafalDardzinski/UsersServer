using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using UsersServer.Database;

namespace UsersServer.User
{
    public class User
    {
        private static readonly UserRepository Repository = new UserRepository(new MsSqlDatabaseManager(AppConfigManager.GetConnectionString()));

        public static void Create(string firstname, string lastname, string username, string password)
        {
            var user = new UserModel
            {
                FirstName = firstname,
                LastName = lastname,
                Username = username,
                Password = password
            };
            Repository.Create(user);
        }

        public static IList<UserModel> Read(int id = 0, string firstname = null, string lastname = null, string username = null)
        {
            var searchProperties = new Dictionary<string, string>
            {
                {"Id", id.ToString()},
                {"FirstName", firstname },
                {"LastName", lastname },
                {"Username", username }

            };

            var searchCriteria = new UserSearchCriteria(searchProperties);
            return Repository.Read(searchCriteria);
        }

        public static void Update(int id, string newFirstName = null, string newLastName = null, string newUsername = null, string newPassword = null)
        {
            var user = Read(id).FirstOrDefault();
            if (user == null)
                throw new InvalidOperationException("User not found.");

            var newProperties = new Dictionary<string, dynamic>
            {
                {"FirstName", newFirstName},
                {"LastName", newLastName},
                {"Username", newUsername},
                {"Password", newPassword}
            };

            var updatedProperties = new UserUpdatedProperties(newProperties);

            Repository.Update(user, updatedProperties);
        }

        public static void Delete(int id)
        {
            var user = Read(id).FirstOrDefault();
            if (user == null)
                throw new InvalidOperationException("User not found.");
            Repository.Delete(user);
        }

        internal class UserSearchCriteria : SearchCriteria<UserModel>
        {
            public UserSearchCriteria(Dictionary<string, string> filterProperties) : base(filterProperties)
            {
            }

            public override void ApplyToQuery(IQueryOver<UserModel, UserModel> query)
            {
                _filterProperties.TryGetValue("Id", out var idValue);
                _filterProperties.TryGetValue("Username", out var username);
                _filterProperties.TryGetValue("FirstName", out var firstName);
                _filterProperties.TryGetValue("LastName", out var lastName);

                if (int.Parse(idValue) > 0)
                    query.Where(u => u.Id == int.Parse(idValue));
                if (!String.IsNullOrEmpty(username))
                    query.Where(u => u.Username == username);
                if (!String.IsNullOrEmpty(firstName))
                    query.Where(u => u.FirstName == firstName);
                if (!String.IsNullOrEmpty(lastName))
                    query.Where(u => u.LastName == lastName);
            }
        }

        internal class UserUpdatedProperties : UpdatedProperties<UserModel>
        {
            public UserUpdatedProperties(Dictionary<string, dynamic> properties) : base(properties)
            {
            }

            public override UserModel Set(UserModel user)
            {
                _properties.TryGetValue("Username", out var username);
                _properties.TryGetValue("FirstName", out var firstName);
                _properties.TryGetValue("LastName", out var lastName);
                _properties.TryGetValue("Password", out var password);

                user.Username = username ?? user.Username;
                user.FirstName = firstName ?? user.FirstName;
                user.LastName = lastName ?? user.LastName;
                user.Password = password ?? user.Password;

                return user;
            }
        }

    }

}
