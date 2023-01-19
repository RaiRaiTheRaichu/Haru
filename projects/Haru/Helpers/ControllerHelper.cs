using WebSocketSharp.Net;
using Haru.Models.EFT;

namespace Haru.Helpers
{
    public class ControllerHelper
    {
        public string GetSessionId(HttpListenerRequest request)
        {
            return request.Headers["SessionId"];
        }

        public ResponseModel<object> GetEmptyResponse()
        {
            return new ResponseModel<object>(null);
        }

        public ResponseModel<object[]> GetEmptyArrayResponse()
        {
            return new ResponseModel<object[]>(new object[0]);
        }
    }
}