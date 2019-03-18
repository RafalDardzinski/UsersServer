using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using UsersServer.Database;

namespace UsersServer.Group
{
    public class Group
    {
        private static readonly GroupRepository Repository = new GroupRepository(new MsSqlDatabaseManager(AppConfigManager.GetConnectionString()));

        public static void Create(string name)
        {
            var group = new GroupModel
            {
                Name = name,
                
            };
            Repository.Create(group);
        }

        public static IList<GroupModel> Read(int id = 0, string name = "")
        {
            var searchProperties = new Dictionary<string, string> {{"Id", id.ToString()}, {"Name", name}};
            var searchCriteria = new GroupSearchCriteria(searchProperties);

            return Repository.Read(searchCriteria);

        }

        public static void Update(int id, string name)
        {
            var newProperties = new Dictionary<string, dynamic> {{"Name", name}};

            var group = Read(id).FirstOrDefault();
            var updatedProperties = new GroupUpdatedProperties(newProperties);
            Repository.Update(group, updatedProperties);
        }

        public static void Delete(int id)
        {
            var group = Read(id).FirstOrDefault();
            Repository.Delete(group);
        }
    }

    internal class GroupSearchCriteria : SearchCriteria<GroupModel>
    {
        public GroupSearchCriteria(Dictionary<string, string> filterProperties) : base(filterProperties)
        {
        }

        public override void ApplyToQuery(IQueryOver<GroupModel, GroupModel> query)
        {
            _filterProperties.TryGetValue("Id", out var idValue);
            _filterProperties.TryGetValue("Name", out var name);

            if (int.Parse(idValue) > 0)
                query.Where(g => g.Id == int.Parse(idValue));
            if (!String.IsNullOrEmpty(name))
                query.Where(g => g.Name == name);

        }
    }

    internal class GroupUpdatedProperties : UpdatedProperties<GroupModel>
    {
        public GroupUpdatedProperties(Dictionary<string, dynamic> properties) : base(properties)
        {
            
        }

        public override GroupModel Set(GroupModel group)
        {
            _properties.TryGetValue("Name", out var name);

            group.Name = name ?? group.Name;

            return group;
        }
    }
}
