using System.Threading.Tasks;
using Haru.Models;
using Haru.Models.EFT.Request;
using Haru.Http;
using Haru.Helpers;

namespace Haru.Controllers
{
    public class GameVersionValidateController : Controller
    {
        public override bool IsMatch(RouterContext context)
        {
            return _requestHelper.GetPath(context.Request) == "/client/game/version/validate";
        }

        public override async Task Run(RouterContext context)
        {
            var body = _controllerHelper.GetEmptyResponse();
            var json = _json.Serialize(body);
            await SendJson(context, json);
        }
    }
}