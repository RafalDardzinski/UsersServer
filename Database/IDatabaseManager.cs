namespace UsersServer.Database
{
    public interface IDatabaseManager
    {
        void Execute(RepositoryCommand command);
    }
}
