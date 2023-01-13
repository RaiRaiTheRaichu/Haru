using System.Threading.Tasks;
using Haru.Models;
using Haru.Models.EFT.Request;
using Haru.Http;
using Haru.Helpers;

namespace Haru.Controllers
{
    public class GameVersionValidateController : Controller
    {
        private const string _gameVersion = "0.13.0.1.21531";
        private readonly ControllerHelper _controllerHelper;

        public GameVersionValidateController()
        {
            _controllerHelper = new ControllerHelper();
        }

        public override bool IsMatch(RouterContext context)
        {
            return _requestHelper.GetPath(context.Request) == "/client/game/version/validate";
        }

        public override async Task Run(RouterContext context)
        {
            var request = await _requestHelper.GetBody(context.Request);
            var info = _json.Deserialize<VersionValidateModel>(request);
            var body = _controllerHelper.GetEmptyResponse();
            
            if (info.Version.Major != _gameVersion)
            {
                // error message taken from "/client/menu/locale/en"
                body.ErrorCode = 1;
                body.ErrorMessage = "BATTLEYE_ANTICHEAT_BadServiceVersion";
            }

            var json = _json.Serialize(body);
            await SendJson(context, json);
        }
    }
}