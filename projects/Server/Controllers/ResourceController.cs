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
        public override bool IsMatch(RouterContext context)
        {
            var url = RequestHelper.GetPath(context.Request);
            return ResourceService.HasFile(url);
        }

        public override async Task Run(RouterContext context)
        {
            var url = RequestHelper.GetPath(context.Request);            
            var file = ResourceService.GetFile(url);
            var data = Resource.GetData(file);
            await Send(context.Response, data);
        }
    }
}