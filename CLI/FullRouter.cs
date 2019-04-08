using System;
using System.Linq;
using CommandLine;
using UsersServer.AppConfig;
using UsersServer.CLI.Options;
using UsersServer.Database;
using UsersServer.Factory;
using UsersServer.Logger;

namespace UsersServer.CLI
{
    /// <summary>
    /// Provides access to all application's functionalities.
    /// </summary>
    class FullRouter : Router, ICommandLineRouter
    {
        private readonly IServiceFactory ServiceFactory;

        public FullRouter(ILogger logger, IDatabase database, IConfigManager configManager, IServiceFactory serviceFactory) : base(logger, database, configManager)
        {
            ServiceFactory = serviceFactory;
        }

        public override void Route(string[] args)
        {
            Database.Connect(ConfigManager);

            using (var session = Database.Session.OpenSession())
            {
                Parser.Default.ParseArguments<
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
                   GroupDelete>(args)
               .MapResult(
                   (DatabaseCreate o) =>
                   {
                       CreateDb(o.ServerInstance, o.DatabaseName);
                       return 0;
                   },
                   (UserCreate u) =>
                   {
                       ServiceFactory.CreateUserService(session)
                           .Create(u.FirstName, u.LastName, u.Username, u.Password);
                       Logger.Log("User created.");
                       return 0;
                   },
                   (UserRead c) =>
                   {
                       var users = ServiceFactory.CreateUserService(session)
                           .Read(c.Id, c.FirstName, c.LastName, c.Username);
                       Logger.Log(users);
                       return 0;
                   },
                   (UserUpdate u) =>
                   {
                       ServiceFactory.CreateUserService(session)
                           .Update(u.Id, u.FirstName, u.LastName, u.Username);
                       Logger.Log("User updated.");
                       return 0;
                   },
                   (UserAddToGroup p) =>
                   {
                       var group = ServiceFactory.CreateGroupService(session)
                           .Read(p.GroupId).FirstOrDefault();
                       if (group == null)
                           throw new InvalidOperationException($"Could not find a group with ID of {p.GroupId}");

                       ServiceFactory.CreateUserService(session)
                           .AddToGroup(p.UserId, group);
                       Logger.Log($"User added to group: {group.Name}");
                       return 0;
                   },
                   (UserRemoveFromGroup p) =>
                   {
                       var group = ServiceFactory.CreateGroupService(session)
                           .Read(p.GroupId).FirstOrDefault();
                       if (group == null)
                           throw new InvalidOperationException($"Could not find a group with ID of {p.GroupId}");

                       ServiceFactory.CreateUserService(session)
                           .RemoveFromGroup(p.UserId, group);
                       Logger.Log($"User is no longer part of the group: {group.Name}");
                       return 0;
                   },
                   (UserPasswordUpdate u) =>
                   {
                       ServiceFactory.CreateUserService(session)
                           .Update(u.Id, newPassword: u.Password);
                       Logger.Log($"Password changed.");
                       return 0;
                   },
                   (UserDelete u) =>
                   {
                       ServiceFactory.CreateUserService(session)
                           .Delete(u.Id);
                       Logger.Log("User deleted.");
                       return 0;
                   },
                   (GroupCreate g) =>
                   {
                       ServiceFactory.CreateGroupService(session)
                           .Create(g.Name);
                       Logger.Log("Group created.");
                       return 0;
                   },
                   (GroupRead g) =>
                   {
                       var groups = ServiceFactory.CreateGroupService(session)
                           .Read(g.Id, g.Name);
                       Logger.Log(groups);
                       return 0;
                   },
                   (GroupUpdate g) =>
                   {
                       ServiceFactory.CreateGroupService(session)
                           .Update(g.Id, g.Name);
                       Logger.Log("Group updated.");
                       return 0;
                   },
                   (GroupDelete g) =>
                   {
                       ServiceFactory.CreateGroupService(session)
                           .Delete(g.Id);
                       Logger.Log("Group deleted. Removed all references to the group from user instances.");
                       return 0;
                   },
                   errs => 1
               );
            }
        }
    }
}
