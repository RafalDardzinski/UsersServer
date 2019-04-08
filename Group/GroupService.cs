using NHibernate;
using System;
using System.Collections.Generic;
using UsersServer.Repository;

namespace UsersServer.Group
{
    public class GroupService : IGroupService
    {
        private readonly ISession _session;
        private readonly IGroupRepository _repository;

        public GroupService(ISession session)
        {
            _session = session;
            _repository = new GroupRepository(session);
        }

        public void Create(string name)
        {
            using (var tx = _session.BeginTransaction())
            {
                try
                {
                    var group = new GroupModel
                    {
                        Name = name
                    };

                    _repository.Create(group);
                    tx.Commit();
                }
                catch (Exception e)
                {
                    tx.Rollback();
                    throw e;
                }
            }
        }

        public IList<GroupModel> Read(int id = 0, string name = null)
        {
            var searchProperties = new Dictionary<string, string> { { "GroupId", id.ToString() }, { "Name", name } };
            var searchCriteria = new GroupSearchCriteria(searchProperties);

            var foundGroups = _repository.Read(searchCriteria);
            return foundGroups;
        }

        public void Update(int id, string newName)
        {
            using (var tx = _session.BeginTransaction())
            {
                try
                {
                    var group = _repository.FindById(id);
                    if (group == null)
                        throw new InvalidOperationException($"Could not find a group with ID: {id}");
                    group.Name = newName ?? group.Name;
                    _repository.Update(group);
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
                    var group = _repository.FindById(id);
                    if (group == null)
                        throw new InvalidOperationException($"Could not find a group with ID: {id}");
                    _repository.Delete(group);
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
