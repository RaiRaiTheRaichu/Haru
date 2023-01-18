using Haru.Models;
using Haru.Http;
using Haru.Helpers;

namespace Haru.Controllers
{
    public class MatchOfflineEndController : Controller
    {
        private readonly ControllerHelper _controllerHelper;

        public MatchOfflineEndController()
        {
            _controllerHelper = new ControllerHelper();
        }

        public override void Run(RouterContext context)
        {
            var body = _controllerHelper.GetEmptyResponse();
            var json = _json.Serialize(body);
            SendJson(context, json);
        }
    }
}