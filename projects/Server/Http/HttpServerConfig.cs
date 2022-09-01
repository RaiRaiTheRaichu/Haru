using System;

namespace Haru.Server.Http
{
    public static class HttpConfig
    {
        public const Uri Uri = "http://127.0.0.1:8000/";

        public HttpConfig(string uri)
        {
            Uri = new Uri(uri);
        }

        public string GetUrl()
        {
            var url = Uri.ToString();
            return url.Remove(url.Length - 1);
        }

        public string GetHost()
        {
            return Uri.Host;
        }

        public int GetPort()
        {
            return Uri.Port;
        }
    }
}