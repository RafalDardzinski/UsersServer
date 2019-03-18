using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersServer
{
    interface IRepository<T> where T : class
    {
        void Create(T modelInstance);
        IList<T> Read(SearchCriteria<T> searchCriteria);
        void Update(T modelInstance, UpdatedProperties<T> updatedProperties);
        void Delete(T modelInstance);
    }
}
