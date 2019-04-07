using System;
using System.Collections.Generic;
using NHibernate;
using UsersServer.Group;
using UsersServer.Repository;

namespace UsersServer.User
{
    class UserService : IUserService
    {
        private readonly ISession _session;
        private readonly IUserRepository _repository;

        public UserService(ISession session)
        {
            _session = session;
            _repository = new UserRepository(session);
        }

        public void Create(string firstname, string lastname, string username, string password)
        {
            using (var tx = _session.BeginTransaction())
            {
                try
                {
                    var user = new UserModel
                    {
                        FirstName = firstname,
                        LastName = lastname,
                        Username = username,
                        Password = password
                    };

                    _repository.Create(user);
                    tx.Commit();
                }
                catch (Exception e)
                {
                    tx.Rollback();
                    throw e;
                }
                
            }
        }

        public IList<UserModel> Read(int id = 0, string firstname = null, string lastname = null, string username = null)
        {
            var searchProperties = new Dictionary<string, string>
            {
                {"UserId", id.ToString()},
                {"FirstName", firstname },
                {"LastName", lastname },
                {"Username", username }
            };

            var searchCriteria = new UserSearchCriteria(searchProperties);
            return _repository.Read(searchCriteria);
        }

        public void Update(int id, string newFirstName = null, string newLastName = null, string newUsername = null,
            string newPassword = null)
        {
            using (var tx = _session.BeginTransaction())
            {
                try
                {
                    var user = _repository.FindById(id);
                    user.FirstName = newFirstName ?? user.FirstName;
                    user.LastName = newLastName ?? user.LastName;
                    user.Username = newUsername ?? user.Username;
                    user.Password = newPassword ?? user.Password;
                    _repository.Update(user);

                    tx.Commit();
                }
                catch (Exception e)
                {
                    tx.Rollback();
                    throw e;
                }
            }
        }

        public void AddToGroup(int userId, GroupModel group)
        {
            using (var tx = _session.BeginTransaction())
            {
                try
                {
                    var user = _repository.FindById(userId);
                    if (user.Groups.Contains(group)) throw new InvalidOperationException($"User is already a part of the group: {group.Name}");
                    user.Groups.Add(group);
                    tx.Commit();
                }
                catch (Exception e)
                {
                    tx.Rollback();
                    throw e;
                }
            }
        }

        public void RemoveFromGroup(int userId, GroupModel group)
        {
            using (var tx = _session.BeginTransaction())
            {
                try
                {
                    var user = _repository.FindById(userId);
                    if (!user.Groups.Contains(group)) throw new InvalidOperationException($"User is not a part of the group: {group.Name}");
                    user.Groups.Remove(group);
                    tx.Commit();
                }
                catch (Exception e)
                {
                    tx.Rollback();
                    throw e;
                }
            }
        }

        public void Delete(int id)
        {
            using (var tx = _session.BeginTransaction())
            {
                try
                {
                    var user = _repository.FindById(id);
                    _repository.Delete(user);
                    tx.Commit();
                }
                catch (Exception e)
                {
                    tx.Rollback();
                    throw e;
                }
            }
        }
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
