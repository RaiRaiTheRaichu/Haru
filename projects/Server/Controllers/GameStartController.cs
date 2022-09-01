using System.Threading.Tasks;
using Haru.Models;
using Haru.Models.EFT;
using Haru.Server.Http;
using Haru.Server.Services;
using Haru.Server.Utils;

namespace Haru.Server.Controllers
{
    public class GameStartController : Controller
    {
        public override async Task Run(RouterContext context)
        {
            if (!context.Request.Url.LocalPath
                .Equals("/client/game/start"))
            {
                return;
            }

            var data = GameService.StartGame();
            var body = new ResponseModel<GameStartModel>(data);
            var json = Json.Serialize(body);
            await SendJson(context.Response, json);
        }
    }
}