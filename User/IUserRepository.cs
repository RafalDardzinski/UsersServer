﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersServer.Repository;

namespace UsersServer.User
{
    public interface IUserRepository : IRepository<UserModel>
    {

    }
}