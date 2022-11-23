using System.Threading.Tasks;
using Haru.Models;
using Haru.Models.EFT;
using Haru.Models.EFT.Friend;
using Haru.Helpers;
using Haru.Http;
using Haru.Services;
using Haru.Utils;

namespace Haru.Controllers
{
    public class FriendListController : Controller
    {
        public override bool IsMatch(RouterContext context)
        {
            return RequestHelper.GetPath(context.Request)
                == "/client/friend/list";
        }

        public override async Task Run(RouterContext context)
        {
            var data = FriendService.GetFriends();
            var body = new ResponseModel<FriendListModel>(data);
            var json = Json.Serialize(body);
            await SendJson(context, json);
        }
    }
}