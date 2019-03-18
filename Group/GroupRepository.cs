﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersServer.Database;
using UsersServer.User;

namespace UsersServer.Group
{
    // Repozytorium dla grupy implementuje standardowe funkcjonalności Repozytorium.
    public class GroupRepository : Repository<GroupModel>
    {
        public GroupRepository(MsSqlDatabaseManager databaseManager) : base(databaseManager)
        {
        }

    }
}
