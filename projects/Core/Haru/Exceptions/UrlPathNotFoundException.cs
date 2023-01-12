using System;

namespace Haru.Exceptions
{
    public class UrlPathNotFoundException : Exception
    {
        public UrlPathNotFoundException(Uri uri) : base(uri.ToString())
        {
        }
    }
}