using CommandLine;

namespace UsersServer.CLI.Options
{
    /// <summary>
    /// user-password-update
    /// </summary>
    [Verb("user-password-update", HelpText = "Change user's password.")]
    public class UserPasswordUpdate
    {
        [Option('i', "id", HelpText = "User's ID", Required = true)]
        public int Id { get; set; }

        [Option('p', "password", HelpText = "New password", Required = true)]
        public string Password { get; set; }
    }
}
