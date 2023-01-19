using Haru.Http;
using Haru.Models;
using Haru.Models.EFT;
using Haru.Models.EFT.Game;
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

        public override void Run(RouterContext context)
        {
            var data = _gameService.GetConfig();
            var body = new ResponseModel<ConfigModel>(data);
            var json = _json.Serialize(body);
            SendJson(context, json);
        }
    }
}