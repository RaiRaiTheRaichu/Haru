using Haru.Http;
using Haru.Models;
using Haru.Services;
using Haru.Utils;

namespace Haru.Controllers
{
    public class ResourceController : Controller
    {
        private readonly Log _log;
        private readonly Resource _resource;
        private readonly ResourceService _resourceService;

        public ResourceController()
        {
            _log = new Log();
            _resource = new Resource();
            _resourceService = new ResourceService();
        }

        public override void Run(RouterContext context)
        {
            var path = _requestHelper.GetPath(context.Request);

            if (_resourceService.TryGetFile(path, out var file))
            {
                var data = _resource.GetData(file);
                Send(context, data);
            }
            else
            {
                _log.Write($"File not found on path {path}");
                context.Response.Close();
            }
        }
    }
}