﻿using System;
using UsersServer.CLI;

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
