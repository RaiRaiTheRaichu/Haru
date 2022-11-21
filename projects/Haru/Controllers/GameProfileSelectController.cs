using System.Threading.Tasks;
using Haru.Models;
using Haru.Models.EFT;
using Haru.Models.EFT.Notification;
using Haru.Helpers;
using Haru.Http;
using Haru.Services;
using Haru.Utils;

namespace Haru.Controllers
{
    public class GameProfileSelectController : Controller
    {
        public override bool IsMatch(RouterContext context)
        {
            return RequestHelper.GetPath(context.Request)
                == "/client/game/profile/select";
        }

        public override async Task Run(RouterContext context)
        {
            var sessionId = RequestHelper.GetSessionId(context.Request);
            var data = NotificationService.SelectProfile(sessionId);
            var body = new ResponseModel<ProfileSelectModel>(data);
            var json = Json.Serialize(body);
            await SendJson(context, json);
        }
    }
}