using Haru.Models;
using Haru.Http;
using Haru.Services;
using Haru.Utils;

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

        public override void Run(RouterContext context)
        {
            var url = _requestHelper.GetPath(context.Request);            
            var file = _resourceService.GetFile(url);
            var data = _resource.GetData(file);
            Send(context, data);
        }
    }
}