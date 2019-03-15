﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersServer.User;

namespace UsersServer.Group
{
    public class GroupModel : Model
    {
        public virtual string Name { get; set; }
        public virtual ICollection<UserModel> Users { get; set; }
    }
}