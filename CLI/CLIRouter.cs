using System;
using CommandLine;
using UsersServer.CLI.Options;
using UsersServer.Database;

namespace UsersServer.CLI
{
    // Klasa odpowiadająca za wywoływanie funkcji serwisów w zależności od inputu przekazanego przez użytkownika.
    class CLIRouter
    {
        public static void Route(string[] args)
        {
            // Aplikacja potrzebuje bazy danych do uruchomienia, dlatego dopóki nie zostanie ona utworzona, nie udostępnia innych funkcjonalności.
            if (String.IsNullOrEmpty(AppConfigManager.GetConnectionString().Value))
            {
                CommandLine.Parser.Default.ParseArguments<DatabaseCreate>(args)
                    .MapResult(
                        (DatabaseCreate o) =>
                        {
                            CreateDb(o.ServerInstance, o.DatabaseName);
                            return 0;
                        },
                        errs =>
                        {
                            Logger.Log("Please create a database first.");
                            return 1;
                        }
                    );
                return;
            }
            
            // Standardowe funkcjonalności udostępnione w momencie gdy w konfiguracji zapisany jest connection string do bazy danych.
            CommandLine.Parser.Default.ParseArguments<
                    DatabaseCreate, 
                    UserCreate, 
                    UserRead,
                    UserUpdate,
                    UserAddToGroup,
                    UserRemoveFromGroup,
                    UserPasswordUpdate,
                    UserDelete,
                    GroupCreate,
                    GroupRead,
                    GroupUpdate,
                    GroupDelete> (args)
                .MapResult(
                    (DatabaseCreate o) =>
                    {
                        CreateDb(o.ServerInstance, o.DatabaseName);
                        return 0;
                    },
                    (UserCreate u) =>
                    {
                        User.User.Create(u.FirstName, u.LastName, u.Username, u.Password);
                        return 0;
                    },
                    //(UserRead c) =>
                    //{
                    //    var users = User.User.Read(c.Id, c.FirstName, c.LastName, c.Username);
                    //    DataDisplayer.Display(users);
                    //    return 0;
                    //},
                    //(UserUpdate u) =>
                    //{
                    //    User.User.Update(u.Id, u.FirstName, u.LastName, u.Username);
                    //    return 0;
                    //},
                    //(UserAddToGroup p) =>
                    //{
                    //    User.User.AddToGroup(p.UserId, p.GroupId);
                    //    return 0;
                    //},
                    //(UserRemoveFromGroup p) =>
                    //{
                    //    User.User.RemoveFromGroup(p.UserId, p.GroupId);
                    //    return 0;
                    //},
                    //(UserPasswordUpdate u) =>
                    //{
                    //    User.User.Update(u.Id, newPassword:u.Password);
                    //    return 0;
                    //},
                    //(UserDelete u) =>
                    //{
                    //    User.User.Delete(u.Id);
                    //    return 0;
                    //},
                    //(GroupCreate g) =>
                    //{
                    //    Group.Group.Create(g.Name);
                    //    return 0;
                    //},
                    //(GroupRead g) =>
                    //{
                    //    var groups = Group.Group.Read(g.Id, g.Name);
                    //    DataDisplayer.Display(groups);
                    //    return 0;
                    //},
                    //(GroupUpdate g) =>
                    //{
                    //    Group.Group.Update(g.Id, g.Name);
                    //    return 0;
                    //},
                    //(GroupDelete g) =>
                    //{
                    //    Group.Group.Delete(g.Id);
                    //    return 0;
                    //},
                    errs => 1
                );
        }

        private static void CreateDb(string serverInstance, string dbName)
        {
            var db = DatabaseService.Db;
            db.Connect(serverInstance);
            var session = db.Session.OpenSession();
            var connectionString = db.Manager.Create(session, serverInstance, dbName);
            db.Session.CloseSession(session);

            AppConfigManager.SetConnectionString(connectionString);
            Logger.Log($"{dbName} created successfully!");
        }
    }
}
