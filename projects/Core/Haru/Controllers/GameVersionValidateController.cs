using Haru.Helpers;
using Haru.Http;
using Haru.Models;

namespace Haru.Controllers
{
    public class GameVersionValidateController : Controller
    {
        private readonly ControllerHelper _controllerHelper;

        public GameVersionValidateController()
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