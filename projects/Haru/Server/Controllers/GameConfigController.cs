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
    public class GameConfigController : Controller
    {
        public override bool IsMatch(RouterContext context)
        {
            return RequestHelper.GetPath(context.Request)
                == "/client/game/config";
        }

        public override async Task Run(RouterContext context)
        {
            var data = GameService.GetConfigModel();
            var body = new ResponseModel<ConfigModel>(data);
            var json = Json.Serialize(body);
            await SendJson(context.Response, json);
        }
    }
}