﻿using CommandLine;

namespace UsersServer.CLI.Options
{
    [Verb("group-create", HelpText = "Add a group to the database")]
    public class GroupCreate
    {
        [Option('n', "name", HelpText = "Name of the group.", Required = true)]
        public string Name { get; set; }
    }
}
