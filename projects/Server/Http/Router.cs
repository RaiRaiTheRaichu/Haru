using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Haru.Models;
using Haru.Server.Helpers;
using Haru.Server.Utils;

namespace Haru.Server.Http
{
    public class Router
    {
        public readonly List<Controller> Controllers;

        public async Task Run(HttpListenerRequest request,
            HttpListenerResponse response)
        {
            var path = RequestHelper.GetPath(request);
            var context = new RouterContext()
            {
                Request = request,
                Response = response,
                HasBody = (request.HttpMethod == "POST")
            };

            Log.Write(path);

            foreach (var controller in Controllers)
            {
                await controller.Run(context);
            }

            // Log.Write($"ERROR - path not found: {context.Request.Url}");
            response.Close();
        }
    }
}