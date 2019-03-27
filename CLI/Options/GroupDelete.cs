using CommandLine;

namespace UsersServer.CLI.Options
{
    [Verb("group-delete", HelpText = "Delete a group")]
    public class GroupDelete
    {
        [Option('i', "id", HelpText = "Group Id.", Required = true)]
        public int Id { get; set; }
    }
}
