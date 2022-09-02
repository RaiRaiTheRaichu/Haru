using System.Threading.Tasks;
using Haru.Models;
using Haru.Models.EFT;
using Haru.Server.Helpers;
using Haru.Server.Http;
using Haru.Server.Services;
using Haru.Server.Utils;

namespace Haru.Server.Controllers
{
    public class GameStartController : Controller
    {
        public override bool IsMatch(RouterContext context)
        {
            return RequestHelper.GetPath(context.Request)
                == "/client/game/start";
        }

        public override async Task Run(RouterContext context)
        {
            var data = GameService.StartGame();
            var body = new ResponseModel<GameStartModel>(data);
            var json = Json.Serialize(body);
            await SendJson(context.Response, json);
        }
    }
}