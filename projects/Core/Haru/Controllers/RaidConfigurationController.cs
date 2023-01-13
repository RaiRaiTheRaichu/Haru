using System.Threading.Tasks;
using Haru.Models;
using Haru.Http;
using Haru.Helpers;

namespace Haru.Controllers
{
    public class RaidConfigurationController : Controller
    {
        private readonly ControllerHelper _controllerHelper;

        public RaidConfigurationController()
        {
            _controllerHelper = new ControllerHelper();
        }

        public override bool IsMatch(RouterContext context)
        {
            return _requestHelper.GetPath(context.Request) == "/client/raid/configuration";
        }

        public override async Task Run(RouterContext context)
        {
            var body = _controllerHelper.GetEmptyResponse();
            var json = _json.Serialize(body);
            await SendJson(context, json);
        }
    }
}
