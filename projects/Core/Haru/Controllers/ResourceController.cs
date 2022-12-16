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
        private readonly RequestHelper _requestHelper;
        private readonly Json _json;
        private readonly Resource _resource;
        private readonly ResourceService _resourceService;

        public ResourceController()
        {
            _requestHelper = new RequestHelper();
            _json = new Json();
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