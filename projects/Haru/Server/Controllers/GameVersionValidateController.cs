using System.Threading.Tasks;
using Haru.Models;
using Haru.Models.EFT;
using Haru.Server.Helpers;
using Haru.Server.Http;
using Haru.Utils;

namespace Haru.Server.Controllers
{
    public class GameVersionValidateController : Controller
    {
        public override bool IsMatch(RouterContext context)
        {
            return RequestHelper.GetPath(context.Request)
                == "/client/game/version/validate";
        }

        public override async Task Run(RouterContext context)
        {
            var body = new ResponseModel<object>(null);
            var json = Json.Serialize(body);
            await SendJson(context, json);
        }
    }
}