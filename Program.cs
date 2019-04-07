using System;
using UsersServer.CLI;
using UsersServer.Factory;

namespace UsersServer
{
    class Program
    {
        static void Main(string[] args)
        {
            var coreFactory = new CoreFactory();
            var router = coreFactory.CreateRouter();
            var errorHandler = coreFactory.CreateErrorHandler();

            try
            {
                router.Route(args);
            }
            catch (Exception e)
            {
                // Delegowanie błędów do klasy je obsługującej
                errorHandler.Handle(e);
            }
        }

    }
}
