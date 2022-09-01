using System.Threading.Tasks;
using Haru.Server.Events;
using Haru.Server.Http;
using Haru.Models.EFT;
using Haru.Server.Services;
using Haru.Server.Utils;

namespace Haru.Server.Controllers
{
    public class GameConfigController : Controller
    {
        public override async Task Run(RouterContext context)
        {
            if (!context.Request.Url.LocalPath
                .Equals("/client/game/config"))
            {
                return;
            }

            var data = GameService.GetGameConfigModel();
            var body = new ResponseModel<GameConfigModel>(data);
            var json = Json.Serialize(body);
            await SendJson(context.response, json);
        }
    }
}