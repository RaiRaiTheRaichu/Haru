using System;

namespace Haru.Extensions
{
    public class ControllerAlreadyAddedException : Exception
    {
        public ControllerAlreadyAddedException(string message) : base(message)
        {
        }
    }
}