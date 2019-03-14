using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersServer.ErrorHandler
{
    class ErrorHandler
    // klasa docelowo obsługująca wyjątki na podstawie typów. Póki co prosta implementacja usuwająca stack trace. 
    {
        public static void Handle(Exception exception)
        {
#if DEBUG
            Console.WriteLine(exception.Message);
            Console.WriteLine(exception.StackTrace);
            return;
#endif
            Handle((dynamic) exception);
        }

        public static void Handle(SqlException exception)
        {
            Console.WriteLine(exception.Message);
        }

    }
}
