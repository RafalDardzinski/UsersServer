using System.Collections.Generic;
using UsersServer.Database;

namespace UsersServer
{
    // Użyłem delegatu aby przenieść odpowiedzialność zarządzania sesją i tranzakcją (otwieranie / zamykanie) na DatabaseManagera, a w Repozytorium trzymać tylko logikę operacji na sesji.
    public delegate void RepositoryCommand(NHibernate.ISession session);

    // Repozytorium odpowiada za wykonywanie podstawowych CRUD-owych operacji na bazie danych.
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        private T _resourceToAdd;
        private T _resourceToUpdate;
        private T _resourceToDelete;
        private IList<T> _resourcesFound;

        protected SearchCriteria<T> SearchCriteria;
        protected readonly MsSqlDatabaseManager DatabaseManager;
        protected Repository(MsSqlDatabaseManager databaseManager)
        {
            DatabaseManager = databaseManager;
        }

        // Zapisuje instancję modelu do bazy danych.
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

        // Znajdź rekordy i je zwróć.
        public virtual IList<T> Read(SearchCriteria<T> searchCriteria)
        {

            SearchCriteria = searchCriteria;
            UsersServer.RepositoryCommand cmd = _Read;
            DatabaseManager.Execute(cmd);
            return _resourcesFound;
        }

        private void _Read(NHibernate.ISession session)
        {
            var query = session.QueryOver<T>();
            SearchCriteria.ApplyToQuery(query);
            _resourcesFound = query.List();
        }

        // Zaktualizuj instancję modelu na podstawie przekazanych właściwości.
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

        // Usuń rekord.
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
