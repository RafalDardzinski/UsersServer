using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersServer.ErrorHandler
{
    // Docelowa obsługa wyjątków na podstawie ich typów. Póki co prosta implementacja usuwająca stack trace jeśli aplikacja nie jest uruchomiona w trybie DEBUG. 
    class ErrorHandler
    {
        public static void Handle(Exception e)
        {
#if DEBUG
            throw e;
#endif
            Logger.Log(e.Message); ;
        }
    }
}
