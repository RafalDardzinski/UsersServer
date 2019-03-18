using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;

namespace UsersServer
{
    public abstract class SearchCriteria<T> where T : class
    {
        protected readonly Dictionary<string, string> _filterProperties;
        public SearchCriteria(Dictionary<string, string> filterProperties)
        {
            _filterProperties = filterProperties;
        }

        // Modyfikuje zapytanie dodając do niego filtry w zależności od tego czy dana własność jest "zdefiniowana".
        public abstract void ApplyToQuery(IQueryOver<T, T> query);

    }
}