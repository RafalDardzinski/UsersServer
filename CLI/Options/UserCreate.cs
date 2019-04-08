using CommandLine;

namespace UsersServer.CLI.Options
{
    /// <summary>
    /// user-create
    /// </summary>
    [Verb("user-create", HelpText = "Adds user to a database")]
    public class UserCreate
    {
        [Option('f', "first-name", HelpText = "User's first name.", Required = true)]
        public string FirstName { get; set; }

        [Option('l', "last-name", HelpText = "User's last name", Required = true)]
        public string LastName { get; set; }

        [Option('u', "username", HelpText = "User's username", Required = true)]
        public string Username { get; set; }

        [Option('p', "password", HelpText = "User's password", Required = true)]
        public string Password { get; set; }
    }
}
