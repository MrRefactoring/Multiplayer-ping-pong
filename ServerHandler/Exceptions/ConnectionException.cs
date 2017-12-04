using System;

namespace ServerHandler.Exceptions
{
    public class ConnectionException: ApplicationException
    {
        public ConnectionException() : base() {}
        public ConnectionException(string message): base(message){}
    }
}