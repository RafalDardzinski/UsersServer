using System.Collections.Generic;

namespace UsersServer.Repository
{
	public interface IRepository<T> where T : class
    {
	    T FindById(object key);
        void Create(T modelInstance);
        IList<T> Read(ISearchCriteria<T> searchCriteria);
        void Update(T updatedModelInstance);
        void Delete(T modelInstance);
    }
}
