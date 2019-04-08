using CommandLine;

namespace UsersServer.CLI.Options
{
    /// <summary>
    /// group-read
    /// </summary>
    [Verb("group-read", HelpText = "Search for groups in the database. Not passing any arguments will result in displaying all the users.")]
    public class GroupRead
    {
        [Option('i', "id", HelpText = "Group Id.", Required = false)]
        public int Id { get; set; }

        [Option('n', "name", HelpText = "Name of the group.", Required = false)]
        public string Name { get; set; }
    }
}
