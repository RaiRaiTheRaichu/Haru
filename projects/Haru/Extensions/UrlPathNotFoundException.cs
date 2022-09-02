using System;

namespace Haru.Extensions
{
    public class UrlPathNotFoundException : Exception
    {
        public UrlPathNotFoundException(Uri uri) : base(uri.ToString())
        {
        }
    }
}