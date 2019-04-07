using System;
using UsersServer.Logger;

namespace UsersServer.ErrorHandler
{
    // Docelowa obsługa wyjątków na podstawie ich typów. Póki co prosta implementacja usuwająca stack trace jeśli aplikacja nie jest uruchomiona w trybie DEBUG. 
    class ErrorHandler : IErrorHandler
    {
        private readonly ILogger Logger;

        public ErrorHandler(ILogger logger)
        {
            Logger = logger;
        }

        public void Handle(Exception e)
        {
#if DEBUG
            throw e;
#endif
            Logger.Log(e.Message); ;
        }
    }
}
