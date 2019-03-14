using System;
using System.Collections.Generic;
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
            Console.WriteLine(exception.Message);
        }
    }
}
