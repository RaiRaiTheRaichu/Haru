using System.Collections.Generic;
using System.Threading.Tasks;
using Haru.Models;
using Haru.Models.EFT;
using Haru.Server.Helpers;
using Haru.Server.Http;
using Haru.Server.Services;
using Haru.Server.Utils;

namespace Haru.Server.Controllers
{
    public class ResourceController : Controller
    {
        public override async Task Run(RouterContext context)
        {
            var url = RequestHelper.GetPath(context.Request);
            var file = ResourceService.GetFile(url);

            if (file != null)
            {
                return;
            }
            
            var data = ResourceHandler.GetData(file);
            await Send(context.Response, data);
        }
    }
}