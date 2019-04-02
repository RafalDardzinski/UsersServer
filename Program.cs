using System;
using UsersServer.CLI;
using UsersServer.Database;

namespace UsersServer
{
    class Program
    {
        // 

        static void Main(string[] args)
        {
                CLIRouter.Route(args);
            try
            {
            }
            catch (Exception e)
            {
                // Delegowanie błędów do klasy je obsługującej
                ErrorHandler.ErrorHandler.Handle(e);
            }
        }

    }
}
