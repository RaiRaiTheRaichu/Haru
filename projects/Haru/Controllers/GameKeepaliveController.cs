using Haru.Http;
using Haru.Models;
using Haru.Models.EFT;
using Haru.Models.EFT.Game;
using Haru.Services;

namespace Haru.Controllers
{
    public class GameKeepaliveController : Controller
    {
        private readonly GameService _gameService;

        public GameKeepaliveController()
        {
            _gameService = new GameService();
        }

        public override void Run(RouterContext context)
        {
            var data = _gameService.GetKeepalive();
            var body = new ResponseModel<KeepaliveModel>(data);
            var json = _json.Serialize(body);
            SendJson(context, json);
        }
    }
}