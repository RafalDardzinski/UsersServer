using System.Collections.Generic;
using NHibernate;

namespace UsersServer.Repository
{
    public abstract class SearchCriteria<T> : ISearchCriteria<T> where T : class
    {
        protected readonly Dictionary<string, string> FilterProperties;

        protected SearchCriteria(Dictionary<string, string> filterProperties)
        {
            FilterProperties = filterProperties;
        }

        // Modyfikuje zapytanie dodając do niego filtry. Dla każdego modelu musi być zdefiniowana oddzielnie.
        public abstract void ApplyToQuery(IQueryOver<T, T> query);

    }
}