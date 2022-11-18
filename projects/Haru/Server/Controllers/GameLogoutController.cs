using System.Threading.Tasks;
using Haru.Models;
using Haru.Models.EFT;
using Haru.Server.Helpers;
using Haru.Server.Http;
using Haru.Server.Services;
using Haru.Utils;

namespace Haru.Server.Controllers
{
    public class GameLogoutController : Controller
    {
        public override bool IsMatch(RouterContext context)
        {
            return RequestHelper.GetPath(context.Request)
                == "/client/game/logout";
        }

        public override async Task Run(RouterContext context)
        {
            var data = GameService.StartGame();
            var body = new ResponseModel<object>(null);
            var json = Json.Serialize(body);
            await SendJson(context, json);
        }
    }
}