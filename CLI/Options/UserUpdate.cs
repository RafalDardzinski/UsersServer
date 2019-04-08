using CommandLine;

namespace UsersServer.CLI.Options
{
    /// <summary>
    /// user-update
    /// </summary>
    [Verb("user-update", HelpText = "Search user by Id and update his/her data.")]
    public class UserUpdate
    {
        [Option('i', "id", HelpText = "User's ID", Required = true)]
        public int Id { get; set; }

        [Option('f', "first-name", HelpText = "New first name", Required = false)]
        public string FirstName { get; set; }

        [Option('l', "last-name", HelpText = "New last name", Required = false)]
        public string LastName { get; set; }

        [Option('u', "username", HelpText = "New username", Required = false)]
        public string Username { get; set; }
    }
}
