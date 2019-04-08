using NHibernate;

namespace UsersServer.Repository
{
    /// <summary>
    /// Provides method to modify search query based on provided properties.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ISearchCriteria<T> where T : class
    {
        /// <summary>
        /// Modifies the search query.
        /// </summary>
        /// <param name="query"></param>
        void ApplyToQuery(IQueryOver<T, T> query);
    }
}
