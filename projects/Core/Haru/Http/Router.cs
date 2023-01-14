using System.Collections.Generic;
using System.Linq;
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
        public readonly List<Controller> Controllers;

        public Router()
        {
            _requestHelper = new RequestHelper();
            _log = new Log();
            Controllers = new List<Controller>();
        }

        public void Run(HttpListenerRequest request, HttpListenerResponse response)
        {
            // log path
            var path = _requestHelper.GetPath(request);
            _log.Write(path);

            // run controller
            var context = new RouterContext()
            {
                Request = request,
                Response = response
            };

            Controllers
                .First(x => x.IsMatch(context))
                .Run(context);
        }
    }
}