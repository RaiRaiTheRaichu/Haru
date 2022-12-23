using System.Threading.Tasks;
using Haru.Framework.Models;
using Haru.Framework.Http;
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

        public override async Task Run(RouterContext context)
        {
            var body = _controllerHelper.GetEmptyArrayResponse();
            var json = _json.Serialize(body);
            await SendJson(context, json);
        }
    }
}
