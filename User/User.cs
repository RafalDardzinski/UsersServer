using System;
using System.Collections.Generic;
using System.Linq;
using NHibernate;
using UsersServer.Database;
using UsersServer.Group;
using UsersServer.Repository;

namespace UsersServer.User
{
    // Serwis udostępniający funkcjonalności dla Użytkownika. Jest bezpośrednim łącznikiem pomiędzy Repozytorium a CLI.
    public class User
    {
        private static readonly IDatabase Database = DatabaseService.GetDatabase();

        // Tworzy użytkownika.
        public static void Create(string firstname, string lastname, string username, string password)
        {
            var session = Database.Session.OpenSession();
            var repository = new UserRepository(session);

            var user = new UserModel
            {
                FirstName = firstname,
                LastName = lastname,
                Username = username,
                Password = password
            };
            repository.Create(user);

            Database.Session.CloseSession(session);
            Logger.Log("User created.");
        }

        //Zwraca listę użytkowników na podstawie przekazanych kryteriów.
        public static IList<UserModel> Read(int id = 0, string firstname = null, string lastname = null, string username = null)
        {
            var session = Database.Session.OpenSession();
            var repository = new UserRepository(session);

            var searchProperties = new Dictionary<string, string>
            {
                {"UserId", id.ToString()},
                {"FirstName", firstname },
                {"LastName", lastname },
                {"Username", username }

            };

            var searchCriteria = new UserSearchCriteria(searchProperties);

            var foundUsers = repository.Read(searchCriteria);
            Database.Session.CloseSession(session);
            return foundUsers;
        }

        // Znajduje użytkownika (po id) i aktualizuje jego pola na podstawie przekanych argumentów.
        public static void Update(int id, string newFirstName = null, string newLastName = null, string newUsername = null, string newPassword = null)
        {
            var session = Database.Session.OpenSession();
            var repository = new UserRepository(session);

            var searchProperties = new Dictionary<string, string>
            {
                {"UserId", id.ToString()},
            };

            var user = repository.Read(new UserSearchCriteria(searchProperties)).FirstOrDefault();
            if (user == null)
                throw new InvalidOperationException("User not found.");

            user.FirstName = newFirstName ?? user.FirstName;
            user.LastName = newLastName ?? user.LastName;
            user.Username = newUsername ?? user.Username;
            user.Password = newPassword ?? user.Password;

            repository.Update(user);
            Database.Session.CloseSession(session);

            Logger.Log("User updated.");
        }

        public static void AddToGroup(int userId, int groupId)
        {
            var session = Database.Session.OpenSession();

            var groupRepository = new GroupRepository(session);
            var groupSearchProperties = new Dictionary<string, string>
            {
                { "GroupId", groupId.ToString() }
            };
            var group = groupRepository.Read(new GroupSearchCriteria(groupSearchProperties)).FirstOrDefault();

            var userRepository = new UserRepository(session);
            var userSearchProperties = new Dictionary<string, string>
            {
                {"UserId", userId.ToString()},
            };
            var user = userRepository.Read(new UserSearchCriteria(userSearchProperties)).FirstOrDefault();

            userRepository.AddToGroup(user, group);
            Database.Session.CloseSession(session);
            Logger.Log("User added to group.");
        }

        // Usuwa użytkownika z grupy.
        public static void RemoveFromGroup(int userId, int groupId)
        {
            var session = Database.Session.OpenSession();

            var groupRepository = new GroupRepository(session);
            var groupSearchProperties = new Dictionary<string, string>
            {
                { "GroupId", groupId.ToString() }
            };
            var group = groupRepository.Read(new GroupSearchCriteria(groupSearchProperties)).FirstOrDefault();

            var userRepository = new UserRepository(session);
            var userSearchProperties = new Dictionary<string, string>
            {
                {"UserId", userId.ToString()},
            };
            var user = userRepository.Read(new UserSearchCriteria(userSearchProperties)).FirstOrDefault();

            userRepository.RemoveFromGroup(user, group);
            Database.Session.CloseSession(session);
            Logger.Log("User removed from group.");
        }

        // Znajduje użytkownika (po id) i usuwa go.
        public static void Delete(int id)
        {
            var session = Database.Session.OpenSession();
            var repository = new UserRepository(session);

            var searchProperties = new Dictionary<string, string>
            {
                {"UserId", id.ToString()},
            };

            var user = repository.Read(new UserSearchCriteria(searchProperties)).FirstOrDefault();

            if (user == null)
                throw new InvalidOperationException("User not found.");

            repository.Delete(user);
            Database.Session.CloseSession(session);
            Logger.Log("User removed.");
        }

        internal class UserSearchCriteria : SearchCriteria<UserModel>
        {
            public UserSearchCriteria(Dictionary<string, string> filterProperties) : base(filterProperties)
            {
            }

            // Implementacja właściwa dla modelu Użytkownika.
            public override void ApplyToQuery(IQueryOver<UserModel, UserModel> query)
            {
            FilterProperties.TryGetValue("UserId", out var idValue);
            FilterProperties.TryGetValue("Username", out var username);
            FilterProperties.TryGetValue("FirstName", out var firstName);
            FilterProperties.TryGetValue("LastName", out var lastName);

            if (int.Parse(idValue) > 0)
                query.Where(u => u.UserId == int.Parse(idValue));
            if (!String.IsNullOrEmpty(username))
                query.Where(u => u.Username == username);
            if (!String.IsNullOrEmpty(firstName))
                query.Where(u => u.FirstName == firstName);
            if (!String.IsNullOrEmpty(lastName))
                query.Where(u => u.LastName == lastName);
            }
        }
 
    }
}
