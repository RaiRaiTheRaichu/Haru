using System;

namespace Haru.Framework.Exceptions
{
    public class DIResolutionException : Exception
    {
        public DIResolutionException()
        {
        }

        public DIResolutionException(string message)
            : base(message)
        {
        }
    }
}