using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using UsersServer.Repository;

namespace UsersServer.Group
{
    class GroupManager : IGroupManager
    {
        private readonly ISession _session;
        private readonly IGroupRepository _repository;

        public GroupManager(ISession session, IGroupRepository repository)
        {
            _session = session;
            _repository = repository;
        }

        public void Create(string name)
        {
            var group = new GroupModel
            {
                Name = name
            };

            using (var tx = _session.BeginTransaction())
            {
                _repository.Create(group);
                tx.Commit();
            }
        }

        public IList<GroupModel> Read(int id = 0, string name = null)
        {
            var searchProperties = new Dictionary<string, string> { { "GroupId", id.ToString() }, { "Name", name } };
            var searchCriteria = new GroupSearchCriteria(searchProperties);

            return _repository.Read(searchCriteria);
        }

        public void Update(int id, string newName)
        {
            using (var tx = _session.BeginTransaction())
            {
                var group = _repository.FindById(id);
                group.Name = newName ?? group.Name;
                _repository.Update(group);
                tx.Commit();
            }
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
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
}
