using System.Threading.Tasks;
using Haru.Models;
using Haru.Helpers;
using Haru.Http;
using Haru.Services;
using Haru.Utils;

namespace Haru.Controllers
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
            await Send(context, data);
        }
    }
}