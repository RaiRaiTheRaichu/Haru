using System.Net;
using System.Threading.Tasks;
using Haru.Server.Events;
using Haru.Server.Helpers;
using Haru.Server.Utils;

namespace Haru.Server.Http
{
    public class Router
    {
        public readonly ILog _log;
        private readonly Controller[] _controllers;
        private readonly IEventBus _eventBus;

        public Router(ILog log, Controller[] controllers, IEventBus eventBus)
        {
            _log = log;
            _controllers = controllers;
            _eventBus = eventBus;
        }

        public async Task Run(HttpListenerRequest request,
            HttpListenerResponse response)
        {
            var path = RequestHelper.GetPath(request);
            await _log.Write(path);
            var hasBody = (request.HttpMethod == "POST");

            var routerRequest = new RouterRequest()
            {
                request = request,
                response = response,
                hasBody = hasBody
            };

            await _eventBus.Invoke<RouterRequest>(routerRequest);
            await _log.Write($"ERROR - path not found: {routerRequest.request.Url}");
            response.Close();
        }
    }
}