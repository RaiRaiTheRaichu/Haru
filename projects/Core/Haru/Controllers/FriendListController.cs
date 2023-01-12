using System.Threading.Tasks;
using Haru.Models;
using Haru.Models.EFT;
using Haru.Models.EFT.Friend;
using Haru.Http;
using Haru.Services;

namespace Haru.Controllers
{
    public class FriendListController : Controller
    {
        private readonly FriendService _friendService;

        public FriendListController()
        {
            _friendService = new FriendService();
        }

        public override bool IsMatch(RouterContext context)
        {
            return _requestHelper.GetPath(context.Request) == "/client/friend/list";
        }

        public override async Task Run(RouterContext context)
        {
            var data = _friendService.GetFriends();
            var body = new ResponseModel<FriendListModel>(data);
            var json = _json.Serialize(body);
            await SendJson(context, json);
        }
    }
}