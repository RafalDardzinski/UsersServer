using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersServer.CLI
{
    public interface ICommandLineRouter
    {
        /// <summary>
        /// Routes commands based on provided parameters.
        /// </summary>
        /// <param name="args">CLI parameters passed to the program.</param>
        void Route(string[] args);
    }
}
