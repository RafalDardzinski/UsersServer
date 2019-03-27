using System.Collections.Generic;
using NHibernate;

namespace UsersServer
{
    public abstract class SearchCriteria<T> where T : class
    {
        protected readonly Dictionary<string, string> _filterProperties;

        protected SearchCriteria(Dictionary<string, string> filterProperties)
        {
            _filterProperties = filterProperties;
        }

        // Modyfikuje zapytanie dodając do niego filtry. Dla każdego modelu musi być zdefiniowana oddzielnie.
        public abstract void ApplyToQuery(IQueryOver<T, T> query);

    }
}