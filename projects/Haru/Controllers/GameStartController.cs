using System.Threading.Tasks;
using Haru.Models;
using Haru.Models.EFT;
using Haru.Models.EFT.Game;
using Haru.Helpers;
using Haru.Http;
using Haru.Services;
using Haru.Utils;

namespace Haru.Controllers
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
            var body = new ResponseModel<StartModel>(data);
            var json = Json.Serialize(body);
            await SendJson(context, json);
        }
    }
}