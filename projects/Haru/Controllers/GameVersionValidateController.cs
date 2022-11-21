using System.Threading.Tasks;
using Haru.Models;
using Haru.Helpers;
using Haru.Http;
using Haru.Utils;

namespace Haru.Controllers
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
            var body = RequestHelper.GetEmptyResponse();
            var json = Json.Serialize(body);
            await SendJson(context, json);
        }
    }
}