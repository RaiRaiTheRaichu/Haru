using System;

namespace Haru.Framework.Exceptions
{
    public class UrlPathNotFoundException : Exception
    {
        public UrlPathNotFoundException(Uri uri) : base(uri.ToString())
        {
        }
    }
}