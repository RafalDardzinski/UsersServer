using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersServer.Database
{
    interface IDatabaseManager
    {
        void CreateDatabase(string databaseName);
    }
}
