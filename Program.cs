﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;
using NHibernate.Cfg;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Tool.hbm2ddl;
using UsersServer.CLI;
using UsersServer.Database;
using UsersServer.User;

namespace UsersServer
{
    class Program
    {
        
        static void Main(string[] args)
        {
            try
            {
                CLIRouter.Route(args);
            }
            catch (Exception e)
            {
                // Delegowanie błędów do klasy je obsługującej
                ErrorHandler.ErrorHandler.Handle(e);
            }
        }

    }
}
