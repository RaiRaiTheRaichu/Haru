using Haru.Models;
using Haru.Http;
using Haru.Helpers;

namespace Haru.Controllers
{
    public class FriendRequestListInboxController : Controller
    {
        private readonly ControllerHelper _controllerHelper;

        public FriendRequestListInboxController()
        {
            _controllerHelper = new ControllerHelper();
        }

        public override bool IsMatch(RouterContext context)
        {
            return _requestHelper.GetPath(context.Request) == "/client/friend/request/list/inbox";
        }

        public override void Run(RouterContext context)
        {
            var body = _controllerHelper.GetEmptyArrayResponse();
            var json = _json.Serialize(body);
            SendJson(context, json);
        }
    }
}
