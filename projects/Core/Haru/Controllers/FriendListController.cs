using System.Threading.Tasks;
using Haru.Framework.Models;
using Haru.Models.EFT;
using Haru.Models.EFT.Friend;
using Haru.Framework.Helpers;
using Haru.Framework.Http;
using Haru.Services;
using Haru.Framework.Utils;

namespace Haru.Controllers
{
    public class FriendListController : Controller
    {
        private readonly RequestHelper _requestHelper;
        private readonly Json _json;
        private readonly FriendService _friendService;

        public FriendListController()
        {
            _requestHelper = new RequestHelper();
            _json = new Json();
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