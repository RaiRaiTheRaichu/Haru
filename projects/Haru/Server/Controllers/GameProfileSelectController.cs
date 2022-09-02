using System.Threading.Tasks;
using Haru.Models;
using Haru.Models.EFT;
using Haru.Models.EFT.Game;
using Haru.Server.Helpers;
using Haru.Server.Http;
using Haru.Server.Services;
using Haru.Utils;

namespace Haru.Server.Controllers
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
            var data = GameService.SelectProfile(sessionId);
            var body = new ResponseModel<ProfileSelectModel>(data);
            var json = Json.Serialize(body);
            await SendJson(context, json);
        }
    }
}