using System.Threading.Tasks;
using Haru.Framework.Models;
using Haru.Models.EFT;
using Haru.Models.EFT.Game;
using Haru.Framework.Helpers;
using Haru.Framework.Http;
using Haru.Services;
using Haru.Framework.Utils;

namespace Haru.Controllers
{
    public class GameStartController : Controller
    {
        private readonly RequestHelper _requestHelper;
        private readonly Json _json;
        private readonly GameService _gameService;

        public GameStartController()
        {
            _requestHelper = new RequestHelper();
            _json = new Json();
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