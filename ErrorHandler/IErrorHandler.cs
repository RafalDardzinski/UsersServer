using System;

namespace UsersServer.ErrorHandler
{
    public interface IErrorHandler
    {
        void Handle(Exception e);
    }
}