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

        public Router()
        {
            Controllers = new List<Controller>();
        }

        public async Task Run(HttpListenerRequest request,
            HttpListenerResponse response)
        {
            var path = RequestHelper.GetPath(request);
            Log.Write(path);

            var misses = 0;
            var context = new RouterContext()
            {
                Request = request,
                Response = response,
                HasBody = (request.HttpMethod == "POST")
            };

            foreach (var controller in Controllers)
            {
                if (controller.IsMatch(context))
                {
                    await controller.Run(context);
                }
                else
                {
                    misses++;
                }
            }

            if (misses == Controllers.Count)
            {
                Log.Write($"ERROR - path not found: {context.Request.Url}");
            }

            response.Close();
        }
    }
}