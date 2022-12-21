using System;

namespace Haru.Helpers
{
    public static class HttpHelper
    {
        public static string GetHost(string url)
        {
            return new Uri(url).Host;
        }

        public static int GetPort(string url)
        {
            return new Uri(url).Port;
        }
    }
}