using System;

namespace Haru.Extensions
{
    public class ResourceNotFoundException : Exception
    {
        public ResourceNotFoundException(string message = null) : base(message)
        {
        }
    }
}