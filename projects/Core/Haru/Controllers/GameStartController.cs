using System.Threading.Tasks;
using Haru.Framework.Models;
using Haru.Models.EFT;
using Haru.Models.EFT.Game;
using Haru.Framework.Http;
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

        public override bool IsMatch(RouterContext context)
        {
            return _requestHelper.GetPath(context.Request) == "/client/game/start";
        }

        public override async Task Run(RouterContext context)
        {
            var data = _gameService.StartGame();
            var body = new ResponseModel<StartModel>(data);
            var json = _json.Serialize(body);
            await SendJson(context, json);
        }
    }
}