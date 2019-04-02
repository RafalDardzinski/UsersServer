using System.Collections.Generic;

namespace UsersServer.Repository
{
    interface IRepository<T> where T : class
    {
        void Create(T modelInstance);
        IList<T> Read(ISearchCriteria<T> searchCriteria);
        void Update(T updatedModelInstance);
        void Delete(T modelInstance);
    }
}
