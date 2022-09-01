using System.Threading.Tasks;
using Haru.Models;
using Haru.Models.EFT;
using Haru.Server.Helpers;
using Haru.Server.Http;
using Haru.Server.Services;
using Haru.Server.Utils;

namespace Haru.Server.Controllers
{
    public class GameProfileSelectController : Controller
    {
        public override async Task Run(RouterContext context)
        {
            if (!context.Request.Url.LocalPath
                .Equals("/client/game/profile/select"))
            {
                return;
            }

            var sessionId = RequestHelper.GetSessionId(context.Request);
            var data = GameService.SelectProfile(sessionId);
            var body = new ResponseModel<GameProfileSelectModel>(data);
            var json = Json.Serialize(body);
            await SendJson(context.Response, json);
        }
    }
}