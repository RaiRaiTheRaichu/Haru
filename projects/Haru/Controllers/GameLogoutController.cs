using Haru.Helpers;
using Haru.Http;
using Haru.Models;

namespace Haru.Controllers
{
    public class GameLogoutController : Controller
    {
        private readonly ControllerHelper _controllerHelper;

        public GameLogoutController()
        {
            _controllerHelper = new ControllerHelper();
        }

        public override void Run(RouterContext context)
        {
            // todo: fix this
            // {"err":0,"errmsg":null,"data":{"status":"ok"}}
            var body = _controllerHelper.GetEmptyResponse();
            var json = _json.Serialize(body);
            SendJson(context, json);
        }
    }
}