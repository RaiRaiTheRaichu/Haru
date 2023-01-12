using System.Threading.Tasks;
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

        public override bool IsMatch(RouterContext context)
        {
            return _requestHelper.GetPath(context.Request) == "/client/friend/request/list/outbox";
        }

        public override async Task Run(RouterContext context)
        {
            var body = _controllerHelper.GetEmptyArrayResponse();
            var json = _json.Serialize(body);
            await SendJson(context, json);
        }
    }
}
