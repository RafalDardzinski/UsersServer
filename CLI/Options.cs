using CommandLine;
using CommandLine.Text;

namespace UsersServer.CLI
{
//  Defines options for application's CLI 
    public class Options
    {
        [Option("test", Required = false, HelpText = "This is just a test")]
        public bool Test { get; set; }

    }

    [Verb("database-create", HelpText = "Create a database and setup its schema.")]
    public class DatabaseCreate
    {
        [Option('s', "server", Required = true, HelpText = @"Specify [server]\instance where you want to create the database e.g. localhost\SQLEXPRESS")]
        public string ServerInstance { get; set; }

        [Option('n', "name", Required = true, HelpText = @"Specify the name of the database.")]
        public string DatabaseName { get; set; }

    }

    [Verb("user-add", HelpText = "Create a user in the database.")]
    public class UserAdd
    {
        [Option('s', "connection-string", Required = true, HelpText = "Specify connection string to the database.")]
        public string ConnectionString { get; set; }

        [Option('f', "first-name", Required = true, HelpText = "Specify user's first name.")]
        public string FirstName { get; set; }

        [Option('l', "last-name", Required = true, HelpText = "Specify user's last name.")]
        public string LastName { get; set; }

        [Option('u', "username", Required = true, HelpText = "Specify user's username")]
        public string Username { get; set; }

        [Option('p', "password", Required = true, HelpText = "Specify user's password")]
        public string Password { get; set; }
    }
}