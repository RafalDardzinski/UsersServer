using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersServer.Database
{
    public interface IDatabaseManager
    {
        void Execute(Repository.RepositoryCommand command);
    }
}
