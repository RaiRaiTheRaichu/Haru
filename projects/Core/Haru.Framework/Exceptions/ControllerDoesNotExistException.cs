using System;

namespace Haru.Framework.Exceptions
{
    public class ControllerDoesNotExistException : Exception
    {
        public ControllerDoesNotExistException(string message) : base(message)
        {
        }
    }
}