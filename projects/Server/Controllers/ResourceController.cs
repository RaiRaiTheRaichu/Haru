using System.Threading.Tasks;
using Haru.Models;
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

            if (!ResourceService.HasFile(url))
            {
                return;
            }
            
            var file = ResourceService.GetFile(url);
            var data = Resource.GetData(file);
            await Send(context.Response, data);
        }
    }
}