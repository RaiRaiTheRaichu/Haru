using System;

namespace Haru.Framework.Exceptions
{
    public class ControllerAlreadyAddedException : Exception
    {
        public ControllerAlreadyAddedException(string message) : base(message)
        {
        }
    }
}