using System;

namespace Haru.Extensions
{
    public class ControllerDoesNotExistException : Exception
    {
        public ControllerDoesNotExistException(string message) : base(message)
        {
        }
    }
}