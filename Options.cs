using CommandLine;

namespace UsersServer
{
//  Defines options for application's CLI 
    public class Options
    {
        [Option("test", Required = false, HelpText = "This is just a test")]
        public bool Test { get; set; }

    }

    [Verb("create-db", HelpText = "Creates a database")]
    public class DatabaseOptions
    {
        [Option("name", Required = true, HelpText = "Specify database name")]
        public string DbName { get; set; }

    }
}