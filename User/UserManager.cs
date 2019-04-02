using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using UsersServer.Repository;

namespace UsersServer.User
{
    class UserManager : IUserManager
    {
        private readonly ISession _session;
        private readonly IUserRepository _repository;

        public UserManager(ISession session, IUserRepository repository)
        {
            _session = session;
            _repository = repository;
        }

        public void Create(string firstname, string lastname, string username, string password)
        {
            var user = new UserModel
            {
                FirstName = firstname,
                LastName = lastname,
                Username = username,
                Password = password
            };

            using (var tx = _session.BeginTransaction())
            {
                _repository.Create(user);
                tx.Commit();
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
                var user = _repository.FindById(id);
                user.FirstName = newFirstName ?? user.FirstName;
                user.LastName = newLastName ?? user.LastName;
                user.Username = newUsername ?? user.Username;
                user.Password = newPassword ?? user.Password;
                _repository.Update(user);

                tx.Commit();
            }
        }

        public void AddToGroup(int userId, int groupId)
        {
            throw new NotImplementedException();
        }

        public void RemoveFromGroup(int userId, int groupId)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            using (var tx = _session.BeginTransaction())
            {
                var user = _repository.FindById(id);
                _repository.Delete(user);
                tx.Commit();
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
