using System.Threading.Tasks;
using Haru.Models;
using Haru.Models.EFT;
using Haru.Server.Http;
using Haru.Server.Utils;

namespace Haru.Server.Controllers
{
    public class GameVersionValidateController : Controller
    {
        public override async Task Run(RouterContext context)
        {
            if (!context.Request.Url.LocalPath
                .Equals("/client/game/version/validate"))
            {
                return;
            }

            var body = new ResponseModel<object>(null);
            var json = Json.Serialize(body);
            await SendJson(context.Response, json);
        }
    }
}