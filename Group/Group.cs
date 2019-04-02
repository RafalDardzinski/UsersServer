using System;
using System.Collections.Generic;
using System.Linq;
using NHibernate;
using UsersServer.Database;
using UsersServer.Repository;

namespace UsersServer.Group
{
    public class Group
    {
        private static readonly IDatabase Database = DatabaseService.GetDatabase();

        // Tworzy nową grupę.
        public static void Create(string name)
        {
            var session = Database.Session.OpenSession();
            var repository = new GroupRepository(session);
            var group = new GroupModel
            {
                Name = name,

            };
            repository.Create(group);
            Database.Session.CloseSession(session);
            Logger.Log("Group created.");
        }

        // Zwraca listę grup znalezioną na podstawie przekazanych kryteriów.
        public static IList<GroupModel> Read(int id = 0, string name = null)
        {
            var session = Database.Session.OpenSession();
            var repository = new GroupRepository(session);
            var searchProperties = new Dictionary<string, string> { { "GroupId", id.ToString() }, { "Name", name } };
            var searchCriteria = new GroupSearchCriteria(searchProperties);

            var foundGroups = repository.Read(searchCriteria);
            Database.Session.CloseSession(session);
            return foundGroups;
        }

        // Znajduje grupę (po id) i aktualizuje jej pola na podstawie przekazanych argumentów.
        public static void Update(int id, string newName)
        {
            var session = Database.Session.OpenSession();
            var repository = new GroupRepository(session);

            var searchProperties = new Dictionary<string, string>
            {
                { "GroupId", id.ToString() }
            };
            var group = repository.Read(new GroupSearchCriteria(searchProperties)).FirstOrDefault();

            if (group == null)
                throw new InvalidOperationException("Group not found.");

            group.Name = newName ?? group.Name;

            repository.Update(group);
            Database.Session.CloseSession(session);
            Logger.Log("Group updated.");
        }

        // Znajduje grupę (po id) i usuwa ją.
        public static void Delete(int id)
        {
            var session = Database.Session.OpenSession();
            var repository = new GroupRepository(session);

            var searchProperties = new Dictionary<string, string>
            {
                { "GroupId", id.ToString() }
            };
            var group = repository.Read(new GroupSearchCriteria(searchProperties)).FirstOrDefault();

            repository.Delete(group);
            Database.Session.CloseSession(session);
            Logger.Log("Group deleted. Removed group references from users assigned to the group.");
        }
    }

    internal class GroupSearchCriteria : SearchCriteria<GroupModel>
    {
        public GroupSearchCriteria(Dictionary<string, string> filterProperties) : base(filterProperties)
        {
        }

        // Implementacja właściwa dla modelu grupy.
        public override void ApplyToQuery(IQueryOver<GroupModel, GroupModel> query)
        {
            FilterProperties.TryGetValue("GroupId", out var idValue);
            FilterProperties.TryGetValue("Name", out var name);

            if (int.Parse(idValue) > 0)
                query.Where(g => g.GroupId == int.Parse(idValue));
            if (!String.IsNullOrEmpty(name))
                query.Where(g => g.Name == name);

        }
    }
}
