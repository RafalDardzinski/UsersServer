using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using UsersServer.Database;

namespace UsersServer
{
    public delegate void RepositoryCommand(NHibernate.ISession session);

    public abstract class Repository<T> : IRepository<T> where T : class
    {
        private T _resourceToAdd;
        protected T _resourceToUpdate;
        private T _resourceToDelete;
        private IList<T> _resourcesFound;
        protected SearchCriteria<T> _searchCriteria;

        protected readonly MsSqlDatabaseManager DatabaseManager;
        protected Repository(MsSqlDatabaseManager databaseManager)
        {
            DatabaseManager = databaseManager;
        }

        public virtual void Create(T modelInstance)
        {
            _resourceToAdd = modelInstance;
            RepositoryCommand cmd = _Create;
            DatabaseManager.Execute(cmd);
        }

        private void _Create(NHibernate.ISession session)
        {
            session.Save(_resourceToAdd);
        }

        public virtual IList<T> Read(SearchCriteria<T> searchCriteria)
        {

            _searchCriteria = searchCriteria;
            UsersServer.RepositoryCommand cmd = _Read;
            DatabaseManager.Execute(cmd);
            return _resourcesFound;
        }

        private void _Read(NHibernate.ISession session)
        {
            var query = session.QueryOver<T>();
            _searchCriteria.ApplyToQuery(query);
            _resourcesFound = query.List();
        }

        public void Update(T modelInstance, UpdatedProperties<T> updatedProperties)
        {
            var resource = modelInstance;
            updatedProperties.Set(resource);
            _resourceToUpdate = resource;
            UsersServer.RepositoryCommand cmd = _Update;
            DatabaseManager.Execute(cmd);
        }

        private void _Update(NHibernate.ISession session)
        {
            session.Update(_resourceToUpdate);
        }

        public void Delete(T modelInstance)
        {
            _resourceToDelete = modelInstance;
            UsersServer.RepositoryCommand cmd = _Delete;
            DatabaseManager.Execute(cmd);
        }

        private void _Delete(NHibernate.ISession session)
        {
            session.Delete(_resourceToDelete);
        }
    }
}
