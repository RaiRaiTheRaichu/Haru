using System.Net;
using Yuki.Events;

namespace Haru.Server.Events
{
    public class RouterRequest : Event
    {
        public HttpListenerRequest request;
        public HttpListenerResponse response;
        public bool hasBody;
    }
}