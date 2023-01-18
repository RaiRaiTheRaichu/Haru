using Haru.Models;
using Haru.Models.EFT.Request;
using Haru.Http;
using Haru.Helpers;

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