using System;
using System.Collections.Generic;
using System.Linq;
using NHibernate;
using UsersServer.Database;

namespace UsersServer.User
{
    // Serwis udostępniający funkcjonalności dla Użytkownika. Jest bezpośrednim łącznikiem pomiędzy Repozytorium a CLI.
    public class User
    {
        private static readonly IDatabase Database = DatabaseService.Db;


        // Tworzy użytkownika.
        public static void Create(string firstname, string lastname, string username, string password)
        {
            Database.Connect();

            var user = new UserModel
            {
                FirstName = firstname,
                LastName = lastname,
                Username = username,
                Password = password
            };


            var repository = new UserRepository(Database.Session.OpenSession());

            repository.Create(user);
            Logger.Log("User created.");
        }

        // Zwraca listę użytkowników na podstawie przekazanych kryteriów.
        //public static IList<UserModel> Read(int id = 0, string firstname = null, string lastname = null, string username = null)
        //{
        //    var searchProperties = new Dictionary<string, string>
        //    {
        //        {"UserId", id.ToString()},
        //        {"FirstName", firstname },
        //        {"LastName", lastname },
        //        {"Username", username }

        //    };

        //    var searchCriteria = new UserSearchCriteria(searchProperties);
        //    return Repository.Read(searchCriteria);
        //}

        //// Znajduje użytkownika (po id) i aktualizuje jego pola na podstawie przekanych argumentów.
        //public static void Update(int id, string newFirstName = null, string newLastName = null, string newUsername = null, string newPassword = null)
        //{
        //    var user = Read(id).FirstOrDefault();
        //    if (user == null)
        //        throw new InvalidOperationException("User not found.");

        //    var newProperties = new Dictionary<string, dynamic>
        //    {
        //        {"FirstName", newFirstName},
        //        {"LastName", newLastName},
        //        {"Username", newUsername},
        //        {"Password", newPassword}
        //    };

        //    var updatedProperties = new UserUpdatedProperties(newProperties);

        //    Repository.Update(user, updatedProperties);
        //    Logger.Log("User updated.");
        //}

        //// Dodaje użytkownika do grupy.
        //public static void AddToGroup(int userId, int groupId)
        //{
        //    Repository.AddToGroup(userId, groupId);
        //    Logger.Log("User added to group.");
        //}

        //// Usuwa użytkownika z grupy.
        //public static void RemoveFromGroup(int userId, int groupId)
        //{
        //    Repository.RemoveFromGroup(userId, groupId);
        //    Logger.Log("User removed from group.");
        //}

        //// Znajduje użytkownika (po id) i usuwa go.
        //public static void Delete(int id)
        //{
        //    var user = Read(id).FirstOrDefault();
        //    if (user == null)
        //        throw new InvalidOperationException("User not found.");
        //    Repository.Delete(user);
        //    Logger.Log("User removed.");
        //}

        //internal class UserSearchCriteria : SearchCriteria<UserModel>
        //{
        //    public UserSearchCriteria(Dictionary<string, string> filterProperties) : base(filterProperties)
        //    {
        //    }

        //    // Implementacja właściwa dla modelu Użytkownika.
        //    public override void ApplyToQuery(IQueryOver<UserModel, UserModel> query)
        //    {
        //        _filterProperties.TryGetValue("UserId", out var idValue);
        //        _filterProperties.TryGetValue("Username", out var username);
        //        _filterProperties.TryGetValue("FirstName", out var firstName);
        //        _filterProperties.TryGetValue("LastName", out var lastName);

        //        if (int.Parse(idValue) > 0)
        //            query.Where(u => u.UserId == int.Parse(idValue));
        //        if (!String.IsNullOrEmpty(username))
        //            query.Where(u => u.Username == username);
        //        if (!String.IsNullOrEmpty(firstName))
        //            query.Where(u => u.FirstName == firstName);
        //        if (!String.IsNullOrEmpty(lastName))
        //            query.Where(u => u.LastName == lastName);
        //    }
        //}

        //internal class UserUpdatedProperties : UpdatedProperties<UserModel>
        //{
        //    public UserUpdatedProperties(Dictionary<string, dynamic> properties) : base(properties)
        //    {
        //    }

        //    public override UserModel Set(UserModel user)
        //    {
        //        _properties.TryGetValue("Username", out var username);
        //        _properties.TryGetValue("FirstName", out var firstName);
        //        _properties.TryGetValue("LastName", out var lastName);
        //        _properties.TryGetValue("Password", out var password);

        //        // Jeśli właściwość nie jest zdefiniowana, nie zmieniaj jej.
        //        user.Username = username ?? user.Username;
        //        user.FirstName = firstName ?? user.FirstName;
        //        user.LastName = lastName ?? user.LastName;
        //        user.Password = password ?? user.Password;

        //        return user;
        //    }
        //}

    }

}
