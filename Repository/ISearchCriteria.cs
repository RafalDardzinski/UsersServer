using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;

namespace UsersServer.Repository
{
    public interface ISearchCriteria<T> where T : class
    {
        void ApplyToQuery(IQueryOver<T, T> query);
    }
}
