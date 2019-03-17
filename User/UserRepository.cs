using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Criterion;
using UsersServer.Database;

namespace UsersServer.User
{
    // Repozytorium użytkowników odpowiada za bezpośrednie operacje na bazie danych.
    // Każdej publicznej metodzie odpowiada także metoda prywatna która przekazywana jest do MsSqlDatabaseManager jako delegat a następnie wywoływana z instancją sesji jako argumentem.
    // Dzięki temu logika zapytań pozostaje w repozytorium, a zarządzaniem sesją i tranzakcjami zajmuje się DatabaseManager.
    class UserRepository : Repository
    {
        private UserModel _userToAdd;
        private UserModel _userToUpdate;
        private UserModel _userToDelete;
        private SearchCriteria _searchCriteria;
        private IList<UserModel> _foundUsers;

        public UserRepository(IDatabaseManager databaseManager) : base(databaseManager)
        {
        }

        public void Create(Model model)
        {
            _userToAdd = (UserModel)model;
            RepositoryCommand cmd = _Create;
            DatabaseManager.Execute(cmd);
            Logger.Log("User created.");
        }

        private void _Create(NHibernate.ISession session)
        {
            session.Save(_userToAdd);
        }

        public IList<UserModel> Read(int id, string firstname, string lastname, string username)
        {
            _searchCriteria = new SearchCriteria(id, firstname, lastname, username);
            RepositoryCommand cmd = _Read;
            DatabaseManager.Execute(cmd);
            return _foundUsers;
        }

        private void _Read(NHibernate.ISession session)
        {
            var c = _searchCriteria;
            var query = session.QueryOver<UserModel>();
            if (c.Id != 0)
                query.Where(u => u.Id == c.Id);
            if (!String.IsNullOrEmpty(c.FirstName))
                query.Where(u => u.FirstName == c.FirstName);
            if (!String.IsNullOrEmpty(c.LastName))
                query.Where(u => u.LastName == c.LastName);
            if (!String.IsNullOrEmpty(c.Username))
                query.Where(u => u.Username == c.Username);

            _foundUsers = query.List();
        }


        public void Update(UserModel user, string newFirstName = null, string newLastName = null, string newUsername = null, string newPassword = null)
        {
            if (user == null)
                throw new InvalidOperationException("User does not exist.");
            user.FirstName = newFirstName ?? user.FirstName;
            user.LastName = newLastName ?? user.LastName;
            user.Username = newUsername ?? user.Username;
            user.Password = newPassword ?? user.Password;
            _userToUpdate = user;
            RepositoryCommand cmd = _Update;
            DatabaseManager.Execute(cmd);
            Logger.Log("User updated.");
        }

        private void _Update(NHibernate.ISession session)
        {
            session.SaveOrUpdate(_userToUpdate);
            
        }

        public void Delete(UserModel user)
        {
            _userToDelete = user ?? throw new InvalidOperationException("User does not exist.");
            RepositoryCommand cmd = _Delete;
            DatabaseManager.Execute(cmd);
            Logger.Log("User deleted.");
        }

        private void _Delete(NHibernate.ISession session)
        {
            session.Delete(_userToDelete);
        }
    }

    internal class SearchCriteria
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }

        public SearchCriteria(int id, string firstname, string lastname, string username)
        {
            Id = id;
            FirstName = firstname;
            LastName = lastname;
            Username = username;
        }
    }
}
