using System;
using UsersServer.Logger;

namespace UsersServer.ErrorHandler
{
    /// <summary>
    /// Global application Errorhandler
    /// </summary>
    class ErrorHandler : IErrorHandler
    {
        private readonly ILogger Logger;

        public ErrorHandler(ILogger logger)
        {
            Logger = logger;
        }

        /// <summary>
        /// Handles exceptions based on the mode the application is compiled in.
        /// </summary>
        /// <param name="e"></param>
        public void Handle(Exception e)
        {
#if DEBUG
            throw e;
#endif
            Logger.Log(e.Message); ;
        }
    }
}
