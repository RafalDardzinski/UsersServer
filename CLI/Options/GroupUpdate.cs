using CommandLine;

namespace UsersServer.CLI.Options
{
    /// <summary>
    /// group-update
    /// </summary>
    [Verb("group-update", HelpText = "Change group's properties.")]
    public class GroupUpdate
    {
        [Option('i', "id", HelpText = "Group Id.", Required = true)]
        public int Id { get; set; }

        [Option('n', "name", HelpText = "New name of the group.", Required = false)]
        public string Name { get; set; }
    }
}
