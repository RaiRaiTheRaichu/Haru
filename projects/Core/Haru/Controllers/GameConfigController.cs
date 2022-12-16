using System.Threading.Tasks;
using Haru.Models;
using Haru.Models.EFT;
using Haru.Models.EFT.Game;
using Haru.Helpers;
using Haru.Http;
using Haru.Services;
using Haru.Utils;

namespace Haru.Controllers
{
    public class GameConfigController : Controller
    {
        private readonly RequestHelper _requestHelper;
        private readonly Json _json;
        private readonly GameService _gameService;

        public GameConfigController()
        {
            _requestHelper = new RequestHelper();
            _json = new Json();
            _gameService = new GameService();
        }

        public override bool IsMatch(RouterContext context)
        {
            return _requestHelper.GetPath(context.Request) == "/client/game/config";
        }

        public override async Task Run(RouterContext context)
        {
            var data = _gameService.GetConfigModel();
            var body = new ResponseModel<ConfigModel>(data);
            var json = _json.Serialize(body);
            await SendJson(context, json);
        }
    }
}