using Haru.Models;
using Haru.Http;
using Haru.Helpers;

namespace Haru.Controllers
{
    public class FriendRequestListOutboxController : Controller
    {
        private readonly ControllerHelper _controllerHelper;

        public FriendRequestListOutboxController()
        {
            _controllerHelper = new ControllerHelper();
        }

        public override void Run(RouterContext context)
        {
            var body = _controllerHelper.GetEmptyArrayResponse();
            var json = _json.Serialize(body);
            SendJson(context, json);
        }
    }
}
