using CommandLine;

namespace UsersServer.CLI.Options
{
    [Verb("user-read", HelpText = "Search for user(s) in the database. Not passing any arguments will result in displaying all the users.")]
    public class UserRead
    {
        [Option('i', "id", HelpText = "User's ID", Required = false)]
        public int Id { get; set; }

        [Option('f', "first-name", HelpText = "User's first name.", Required = false)]
        public string FirstName { get; set; }

        [Option('l', "last-name", HelpText = "User's last name", Required = false)]
        public string LastName { get; set; }

        [Option('u', "username", HelpText = "User's username", Required = false)]
        public string Username { get; set; }
    }
}

