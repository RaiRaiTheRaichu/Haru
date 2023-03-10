using Haru.Http;
using Haru.Models;
using Haru.Models.EFT;
using Haru.Models.EFT.Game;
using Haru.Services;

namespace Haru.Controllers
{
    public class CheckVersionController : Controller
    {
        private readonly GameService _gameService;

        public CheckVersionController()
        {
            _gameService = new GameService();
        }

        public override void Run(RouterContext context)
        {
            var data = _gameService.IsCorrectVersion();
            var body = new ResponseModel<CheckVersionModel>(data);
            var json = _json.Serialize(body);
            SendJson(context, json);
        }
    }
}