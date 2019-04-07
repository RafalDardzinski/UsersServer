using System;

namespace UsersServer.ErrorHandler
{
    interface IErrorHandler
    {
        void Handle(Exception e);
    }
}