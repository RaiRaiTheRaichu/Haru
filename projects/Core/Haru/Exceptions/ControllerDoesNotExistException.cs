using System;

namespace Haru.Exceptions
{
    public class ControllerDoesNotExistException : Exception
    {
        public ControllerDoesNotExistException(string message) : base(message)
        {
        }
    }
}