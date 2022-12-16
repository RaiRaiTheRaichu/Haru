using System;

namespace Haru.Extensions
{
    public class LocationNotFoundException : Exception
    {
        public LocationNotFoundException(string message) : base(message)
        {
        }
    }
}