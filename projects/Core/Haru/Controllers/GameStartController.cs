using Haru.Http;
using Haru.Models;
using Haru.Models.EFT;
using Haru.Models.EFT.Game;
using Haru.Services;

namespace Haru.Controllers
{
    public class GameStartController : Controller
    {
        private readonly GameService _gameService;

        public GameStartController()
        {
            _gameService = new GameService();
        }

        public override void Run(RouterContext context)
        {
            var data = _gameService.StartGame();
            var body = new ResponseModel<StartModel>(data);
            var json = _json.Serialize(body);
            SendJson(context, json);
        }
    }
}