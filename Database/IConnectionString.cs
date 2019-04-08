namespace UsersServer.Database
{
    public interface IConnectionString
    {
        /// <summary>
        /// Returns string value of the connection string.
        /// </summary>
        string Value { get; }
    }
}
