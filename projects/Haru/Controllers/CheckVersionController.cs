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
    public class CheckVersionController : Controller
    {
        private readonly RequestHelper _requestHelper;
        private readonly Json _json;
        private readonly GameService _gameService;

        public CheckVersionController()
        {
            _requestHelper = new RequestHelper();
            _json = new Json();
            _gameService = new GameService();
        }

        public override bool IsMatch(RouterContext context)
        {
            return _requestHelper.GetPath(context.Request)
                == "/client/checkVersion";
        }

        public override async Task Run(RouterContext context)
        {
            var data = _gameService.IsCorrectVersion();
            var body = new ResponseModel<CheckVersionModel>(data);
            var json = _json.Serialize(body);
            await SendJson(context, json);
        }
    }
}