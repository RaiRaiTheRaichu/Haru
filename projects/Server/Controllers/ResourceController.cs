using System.Collections.Generic;
using System.Threading.Tasks;
using Haru.Server.Events;
using Haru.Server.Helpers;
using Haru.Server.Http;
using Haru.Resources;
using Haru.Server.Services;
using Haru.Server.Utils;

namespace Haru.Server.Controllers
{
    public class ResourceController : Controller
    {
        public override async Task Run(RouterRequest routerRequest)
        {
            if (!_resourcesPaths.Contains(routerRequest.request.Url.LocalPath))
            {
                // throw exception
                return;
            }

            var url = RequestHelper.GetPath(routerRequest.request);
            var file = ResourceService.GetFile(url);
            var data = await ResourceHandler.GetData(file);
            await Send(routerRequest.response, data);
        }
    }
}