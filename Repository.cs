using System;
using System.Collections.Generic;
using UsersServer.Database;

namespace UsersServer
{
    // Użyłem delegatu aby przenieść odpowiedzialność zarządzania sesją i tranzakcją (otwieranie / zamykanie) na DatabaseManagera, a w Repozytorium trzymać tylko logikę operacji na sesji.
    public delegate void RepositoryCommand(NHibernate.ISession session);

    // Repozytorium odpowiada za wykonywanie podstawowych CRUD-owych operacji na bazie danych.
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        private T _resourceToUpdate;
        protected readonly NHibernate.ISession _session;

        protected SearchCriteria<T> SearchCriteria;

        protected Repository(NHibernate.ISession session)
        {
            _session = session;
        }

        // Zapisuje instancję modelu do bazy danych.
        public virtual void Create(T modelInstance)
        {
            _session.Save(modelInstance);
        }

        // Znajdź rekordy i je zwróć.
        public virtual IList<T> Read(SearchCriteria<T> searchCriteria)
        {
            var query = _session.QueryOver<T>();
            SearchCriteria.ApplyToQuery(query);
            return query.List();
        }

        // Zaktualizuj instancję modelu na podstawie przekazanych właściwości.
        public void Update(T modelInstance, UpdatedProperties<T> updatedProperties)
        {
            throw new NotImplementedException();
            //var resource = modelInstance;
            //updatedProperties.Set(resource);
            //_resourceToUpdate = resource;
            //UsersServer.RepositoryCommand cmd = _Update;
            //DatabaseManager.Execute(cmd);
        }

        private void _Update(NHibernate.ISession session)
        {
            session.Update(_resourceToUpdate);
        }

        // Usuń rekord.
        public void Delete(T modelInstance)
        {
            _session.Delete(modelInstance);
        }
    }
}
