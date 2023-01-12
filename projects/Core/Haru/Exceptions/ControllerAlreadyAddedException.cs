using System;

namespace Haru.Exceptions
{
    public class ControllerAlreadyAddedException : Exception
    {
        public ControllerAlreadyAddedException(string message) : base(message)
        {
        }
    }
}