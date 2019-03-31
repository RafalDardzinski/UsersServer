//using System;
//using System.Collections.Generic;
//using System.Linq;
//using NHibernate;
//using UsersServer.Database;

//namespace UsersServer.Group
//{
//    // Serwis udostępniający funkcjonalności dla Grupy. Jest bezpośrednim łącznikiem pomiędzy Repozytorium a CLI.
//    public class Group
//    {


//        // Tworzy nową grupę.
//        public static void Create(string name)
//        {
//            var group = new GroupModel
//            {
//                Name = name,

//            };
//            Repository.Create(group);
//            Logger.Log("Group created.");
//        }

//        // Zwraca listę grup znalezioną na podstawie przekazanych kryteriów.
//        public static IList<GroupModel> Read(int id = 0, string name = null)
//        {
//            var searchProperties = new Dictionary<string, string> { { "GroupId", id.ToString() }, { "Name", name } };
//            var searchCriteria = new GroupSearchCriteria(searchProperties);

//            return Repository.Read(searchCriteria);

//        }

//        // Znajduje grupę (po id) i aktualizuje jej pola na podstawie przekazanych argumentów.
//        public static void Update(int id, string name)
//        {
//            var group = Read(id).FirstOrDefault();
//            if (group == null)
//                throw new InvalidOperationException("Group not found.");

//            var newProperties = new Dictionary<string, dynamic> { { "Name", name } };
//            var updatedProperties = new GroupUpdatedProperties(newProperties);
//            Repository.Update(group, updatedProperties);
//            Logger.Log("Group updated.");
//        }

//        // Znajduje grupę (po id) i usuwa ją.
//        public static void Delete(int id)
//        {
//            var group = Read(id).FirstOrDefault();
//            Repository.Delete(group);
//            Logger.Log("Group deleted. Removed group references from users assigned to the group.");
//        }
//    }

//    internal class GroupSearchCriteria : SearchCriteria<GroupModel>
//    {
//        public GroupSearchCriteria(Dictionary<string, string> filterProperties) : base(filterProperties)
//        {
//        }

//        // Implementacja właściwa dla modelu grupy.
//        public override void ApplyToQuery(IQueryOver<GroupModel, GroupModel> query)
//        {
//            _filterProperties.TryGetValue("GroupId", out var idValue);
//            _filterProperties.TryGetValue("Name", out var name);

//            if (int.Parse(idValue) > 0)
//                query.Where(g => g.GroupId == int.Parse(idValue));
//            if (!String.IsNullOrEmpty(name))
//                query.Where(g => g.Name == name);

//        }
//    }

//    internal class GroupUpdatedProperties : UpdatedProperties<GroupModel>
//    {
//        public GroupUpdatedProperties(Dictionary<string, dynamic> properties) : base(properties)
//        {

//        }

//        // Implementacja właściwa dla modelu grupy.
//        public override GroupModel Set(GroupModel group)
//        {
//            _properties.TryGetValue("Name", out var name);

//            // Nie zmieniaj właściwości jeśli nie są one zdefiniowane.
//            group.Name = name ?? group.Name;

//            return group;
//        }
//    }
//}
