﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersServer.Database
{
    public interface IConnectionString
    {
        /// <summary>
        /// Returns value of the connection string.
        /// </summary>
        string Value { get; }
    }
}
