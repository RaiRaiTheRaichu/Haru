using System;

namespace Haru.Http
{
    public static class HttpConfig
    {
        public static readonly Uri Uri;

        static HttpConfig()
        {
            Uri = new Uri("http://127.0.0.1:8000/");
        }

        public static string GetUrl()
        {
            var url = Uri.ToString();
            return url.Remove(url.Length - 1);
        }

        public static string GetHost()
        {
            return Uri.Host;
        }

        public static int GetPort()
        {
            return Uri.Port;
        }
    }
}