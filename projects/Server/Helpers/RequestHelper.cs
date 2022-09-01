using System.Net;

namespace Haru.Server.Helpers
{
    public static class RequestHelper
    {
        public static string GetPath(HttpListenerRequest request)
        {
            var url = request.Url;
            var result = url.PathAndQuery;

            if (url.Query.Length > 0)
            {
                result.Replace(url.Query, string.Empty);
            }

            return result;
        }

        public static string GetSessionId(HttpListenerRequest request)
        {
            return request.Headers["SessionId"];
        }
    }
}