using System;

namespace Haru.Server.Http
{
    public class HttpServerConfig
    {
        public Uri Uri;

        public HttpServerConfig(string uri)
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