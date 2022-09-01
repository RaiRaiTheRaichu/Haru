using System.Threading.Tasks;
using Haru.Server.Events;
using Haru.Server.Http;
using Haru.Models.EFT;
using Haru.Server.Utils;

namespace Haru.Server.Controllers
{
    public class GameVersionValidateController : Controller
    {
        private readonly IJson _json;

        public GameVersionValidateController(
            IZlib zlib,
            IJson json,
            IEventBus eventBus) : base(zlib, eventBus)
        {
            _json = json;
        }

        public override async Task Run(RouterRequest routerRequest)
        {
            if (!routerRequest.request.Url.LocalPath.Equals("/client/game/version/validate"))
            {
                return;
            }

            var body = new ResponseModel<object>(null);
            var json = _json.Serialize(body);
            await SendJson(routerRequest.response, json);
        }
    }
}