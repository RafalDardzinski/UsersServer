using System.Collections.Generic;

namespace UsersServer.Repository
{
    /// <summary>
    /// Provides basic CRUD methods for data manipulation.
    /// </summary>
    /// <typeparam name="T">Model</typeparam>
	public interface IRepository<T> where T : class
	{
        /// <summary>
        /// Searches for a single object in the database based on it's ID.
        /// </summary>
        /// <param name="key">Object's unique identifier.</param>
        /// <returns></returns>
		T FindById(object key);

        /// <summary>
        /// Saves the model in the database.
        /// </summary>
        /// <param name="modelInstance">Instance of the model.</param>
		void Create(T modelInstance);

        /// <summary>
        /// Searches for instances of the model saved in the database based on provided search criteria.
        /// </summary>
        /// <param name="searchCriteria"></param>
        /// <returns>List of models saved in the database that matches provided criteria.</returns>
		IList<T> Read(ISearchCriteria<T> searchCriteria);

        /// <summary>
        /// Update an instance of a model that is already saved in the database.
        /// </summary>
        /// <param name="updatedModelInstance">Model instance fetched from the database with updated properties.</param>
		void Update(T updatedModelInstance);

        /// <summary>
        /// Deletes a model instance from the database.
        /// </summary>
        /// <param name="modelInstance">Model instance fetched from the database.</param>
		void Delete(T modelInstance);
	}
}
