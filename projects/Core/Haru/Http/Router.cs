using System.Collections.Generic;
using WebSocketSharp.Net;
using Haru.Models;
using Haru.Helpers;
using Haru.Utils;

namespace Haru.Http
{
    public class Router
    {
        private readonly RequestHelper _requestHelper;
        private readonly Log _log;
        public Dictionary<string, Controller> Controllers;

        public Router()
        {
            _requestHelper = new RequestHelper();
            _log = new Log();
            Controllers = new Dictionary<string, Controller>();
        }

        public void Run(HttpListenerRequest request, HttpListenerResponse response)
        {
            // log path
            var path = _requestHelper.GetPath(request);
            _log.Write(path);

            // run controller
            if (Controllers.TryGetValue(path, out var controller))
            {
                var context = new RouterContext()
                {
                    Request = request,
                    Response = response
                };

                controller.Run(context);
            }
            else
            {
                _log.Write($"No controller found for {path}");
                response.Close();
            }
        }
    }
}