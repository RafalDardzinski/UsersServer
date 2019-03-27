using System;

namespace UsersServer
{
    // Pozwala na logowanie wiadomości. Obecnie po prostu wypisuje wiadomości na konsoli, ale można go w przyszłości rozszerzyć o dodatkowe funkcjonalności.
    public class Logger
    {
        public static void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
