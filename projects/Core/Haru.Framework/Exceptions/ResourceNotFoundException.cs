using System;

namespace Haru.Framework.Exceptions
{
    public class ResourceNotFoundException : Exception
    {
        public ResourceNotFoundException(string message = null) : base(message)
        {
        }
    }
}