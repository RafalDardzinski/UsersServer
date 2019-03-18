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
    class UserRepository : Repository<UserModel>
    {
        public UserRepository(MsSqlDatabaseManager databaseManager) : base(databaseManager)
        {
        }
    }
}
