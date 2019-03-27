using CommandLine;

namespace UsersServer.CLI.Options
{
    [Verb("database-create", HelpText = "Create a database and setup its schema.")]
    public class DatabaseCreate
    {
        [Option('s', "server", Required = true, HelpText = @"Specify [server]\[instance] where you want to create the database e.g. localhost\SQLEXPRESS.")]
        public string ServerInstance { get; set; }

        [Option('n', "name", Required = true, HelpText = @"Specify the name of the database.")]
        public string DatabaseName { get; set; }
    }
}
