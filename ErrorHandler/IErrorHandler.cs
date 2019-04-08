using System;

namespace UsersServer.ErrorHandler
{
    /// <summary>
    /// Provides methods to handle exceptions.
    /// </summary>
    interface IErrorHandler
    {
        /// <summary>
        /// Handle exception.
        /// </summary>
        /// <param name="e"></param>
        void Handle(Exception e);
    }
}