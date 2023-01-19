using Haru.Http;
using Haru.Models;
using Haru.Models.EFT;
using Haru.Models.EFT.Friend;
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

        public override void Run(RouterContext context)
        {
            var data = _friendService.GetFriends();
            var body = new ResponseModel<FriendListModel>(data);
            var json = _json.Serialize(body);
            SendJson(context, json);
        }
    }
}