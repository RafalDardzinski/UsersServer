using System;
using System.Collections.Generic;

namespace UsersServer.Repository
{
	// Repozytorium odpowiada za wykonywanie podstawowych CRUD-owych operacji na bazie danych.
	public abstract class Repository<T> : IRepository<T> where T : class
	{
		protected readonly NHibernate.ISession Session;

		protected Repository(NHibernate.ISession session)
		{
			Session = session;
		}

		public virtual T FindById(object key)
		{
			return Session.Get<T>(key);
		}

		// Zapisuje instancję modelu do bazy danych.
		public virtual void Create(T modelInstance)
		{
			Session.Save(modelInstance);
		}

		// Znajdź rekordy i je zwróć.
		public virtual IList<T> Read(ISearchCriteria<T> searchCriteria)
		{
			var query = Session.QueryOver<T>();
			searchCriteria.ApplyToQuery(query);
			return query.List();
		}

		// Zaktualizuj instancję modelu na podstawie przekazanych właściwości.
		public void Update(T updatedModelInstance)
		{
			Session.Update(updatedModelInstance);
		}

		// Usuń rekord.
		public void Delete(T modelInstance)
		{
			Session.Delete(modelInstance);
		}
	}
}
