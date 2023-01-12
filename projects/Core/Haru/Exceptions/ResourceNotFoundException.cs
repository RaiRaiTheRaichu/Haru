using System;

namespace Haru.Exceptions
{
    public class ResourceNotFoundException : Exception
    {
        public ResourceNotFoundException(string message = null) : base(message)
        {
        }
    }
}