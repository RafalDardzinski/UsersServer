using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;

namespace UsersServer.CLI.Options
{
    [Verb("user-add-to-group", HelpText = "Add user to a group.")]
    public class UserAddToGroup
    {
        [Option('u', "user-id", HelpText = "Id of an user to add.", Required = true)]
        public int UserId { get; set; }

        [Option('g', "group-id", HelpText = "Id of a group to add user to.", Required = true)]
        public int GroupId { get; set; }

    }
}
