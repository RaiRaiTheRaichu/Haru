using System.Threading.Tasks;
using Haru.Server.Events;
using Haru.Server.Helpers;
using Haru.Server.Http;
using Haru.Models.EFT;
using Haru.Server.Services;
using Haru.Server.Utils;

namespace Haru.Server.Controllers
{
    public class GameProfileSelectController : Controller
    {
        private readonly IJson _json;
        private readonly IGameService _service;

        public GameProfileSelectController(
            IZlib zlib,
            IJson json,
            IGameService gameService,
            IEventBus eventBus) : base(zlib, eventBus)
        {
            _json = json;
            _service = gameService;
        }

        public override async Task Run(RouterRequest routerRequest)
        {
            if (!routerRequest.request.Url.LocalPath.Equals("/client/game/profile/select"))
            {
                return;
            }

            var sessionId = RequestHelper.GetSessionId(routerRequest.request);
            var data = _service.SelectProfile(sessionId);
            var body = new ResponseModel<GameProfileSelectModel>(data);
            var json = _json.Serialize(body);
            await SendJson(routerRequest.response, json);
        }
    }
}