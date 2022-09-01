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
        public override async Task Run(RouterContext context)
        {
            if (!_resourcesPaths.Contains(context.Request.Url.LocalPath))
            {
                return;
            }

            var url = RequestHelper.GetPath(context.Request);
            var file = ResourceService.GetFile(url);
            var data = await ResourceHandler.GetData(file);
            await Send(context.response, data);
        }
    }
}