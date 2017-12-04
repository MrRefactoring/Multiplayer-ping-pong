using System;

namespace ServerHandler.Exceptions
{
    public class ServerNotBindedException: ApplicationException
    {
        public ServerNotBindedException(): base() {}
        public ServerNotBindedException(string message): base(message){}
    }
}