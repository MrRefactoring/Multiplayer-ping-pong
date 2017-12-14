using System;

namespace PingPong.PlayGround.Exceptions
{
    class WindowNotLoadedException: ApplicationException
    {

        public WindowNotLoadedException() : base() { }

        public WindowNotLoadedException(string message) : base(message) { }

    }
}
