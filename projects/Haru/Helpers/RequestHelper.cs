using System.Net;
using Haru.Models.EFT;

namespace Haru.Helpers
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

        public static ResponseModel<object> GetEmptyResponse()
        {
            return new ResponseModel<object>(null);
        }

        public static ResponseModel<object[]> GetEmptyArrayResponse()
        {
            return new ResponseModel<object[]>(new object[0]);
        }
    }
}