using System;

namespace Lib.Exceptions
{
    class PositionNotFullySpecifiedException: ApplicationException
    {

        public PositionNotFullySpecifiedException(): base() { }

        public PositionNotFullySpecifiedException(string message) : base(message) { }

    }
}
