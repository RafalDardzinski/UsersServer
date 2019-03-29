using System.Collections.Generic;

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