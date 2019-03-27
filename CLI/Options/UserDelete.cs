using CommandLine;

namespace UsersServer.CLI.Options
{
    [Verb("user-delete", HelpText = "Delete a user.")]
    public class UserDelete
    {
        [Option('i', "id", HelpText = "User's ID", Required = true)]
        public int Id { get; set; }

    }
}
