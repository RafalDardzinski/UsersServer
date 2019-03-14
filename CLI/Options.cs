using CommandLine;

namespace UsersServer.CLI
{
//  Defines options for application's CLI 
    public class Options
    {
        [Option("test", Required = false, HelpText = "This is just a test")]
        public bool Test { get; set; }

    }

    [Verb("create-db", HelpText = "Create a database and setup its schema.")]
    public class DatabaseCreate
    {
        [Option('s', "server", Required = true, HelpText = @"Specify [server]\instance where for Database to be set e.g. localhost\SQLEXPRESS")]
        public string ServerInstance { get; set; }

        [Option('n', "name", Required = true, HelpText = @"Specify the name of the database.")]
        public string DatabaseName { get; set; }

    }
}