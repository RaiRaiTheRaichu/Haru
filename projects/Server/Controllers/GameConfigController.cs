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
        private readonly IJson _json;
        private readonly IGameService _service;

        public GameConfigController(
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
            if (!routerRequest.request.Url.LocalPath.Equals("/client/game/config"))
            {
                return;
            }

            var data = _service.GetGameConfigModel();
            var body = new ResponseModel<GameConfigModel>(data);
            var json = _json.Serialize(body);
            await SendJson(routerRequest.response, json);
        }
    }
}