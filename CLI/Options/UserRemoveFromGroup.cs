using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;

namespace UsersServer.CLI.Options
{
    [Verb("user-remove-from-group", HelpText = "Remove a user from a group.")]
    public class UserRemoveFromGroup
    {
        [Option('u', "user-id", HelpText = "Id of an user.", Required = true)]
        public int UserId { get; set; }

        [Option('g', "group-id", HelpText = "Id of a group to remove a user from.", Required = true)]
        public int GroupId { get; set; }

    }
}
