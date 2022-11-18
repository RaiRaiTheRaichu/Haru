using System.Threading.Tasks;
using Haru.Models;
using Haru.Models.EFT;
using Haru.Server.Helpers;
using Haru.Server.Http;
using Haru.Server.Services;
using Haru.Utils;

namespace Haru.Server.Controllers
{
    public class FriendRequestListOutboxController : Controller
    {
        public override bool IsMatch(RouterContext context)
        {
            return RequestHelper.GetPath(context.Request)
                == "/client/friend/request/list/outbox";
        }

        public override async Task Run(RouterContext context)
        {
            var data = GameService.GetConfigModel();
            var body = new ResponseModel<object[]>(new object[0]);
            var json = Json.Serialize(body);
            await SendJson(context, json);
        }
    }
}
