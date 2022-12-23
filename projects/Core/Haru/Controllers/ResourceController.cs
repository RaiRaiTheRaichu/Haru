using System.Threading.Tasks;
using Haru.Framework.Models;
using Haru.Framework.Http;
using Haru.Services;
using Haru.Framework.Utils;

namespace Haru.Controllers
{
    public class ResourceController : Controller
    {
        private readonly Resource _resource;
        private readonly ResourceService _resourceService;

        public ResourceController()
        {
            _resource = new Resource();
            _resourceService = new ResourceService();
        }

        public override bool IsMatch(RouterContext context)
        {
            var url = _requestHelper.GetPath(context.Request);
            return _resourceService.HasFile(url);
        }

        public override async Task Run(RouterContext context)
        {
            var url = _requestHelper.GetPath(context.Request);            
            var file = _resourceService.GetFile(url);
            var data = await _resource.GetData(file);
            await Send(context, data);
        }
    }
}