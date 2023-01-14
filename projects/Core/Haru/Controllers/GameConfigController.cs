using Haru.Models;
using Haru.Models.EFT;
using Haru.Models.EFT.Game;
using Haru.Http;
using Haru.Services;

namespace Haru.Controllers
{
    public class GameConfigController : Controller
    {
        private readonly GameService _gameService;

        public GameConfigController()
        {
            _gameService = new GameService();
        }

        public override bool IsMatch(RouterContext context)
        {
            return _requestHelper.GetPath(context.Request) == "/client/game/config";
        }

        public override void Run(RouterContext context)
        {
            var data = _gameService.GetConfigModel();
            var body = new ResponseModel<ConfigModel>(data);
            var json = _json.Serialize(body);
            SendJson(context, json);
        }
    }
}