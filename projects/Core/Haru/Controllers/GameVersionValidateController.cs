using System.Threading.Tasks;
using Haru.Models;
using Haru.Models.EFT.Request;
using Haru.Helpers;
using Haru.Http;
using Haru.Utils;

namespace Haru.Controllers
{
    public class GameVersionValidateController : Controller
    {
        private readonly RequestHelper _requestHelper;
        private readonly Json _json;

        public GameVersionValidateController()
        {
            _requestHelper = new RequestHelper();
            _json = new Json();
        }

        public override bool IsMatch(RouterContext context)
        {
            return _requestHelper.GetPath(context.Request) == "/client/game/version/validate";
        }

        public override async Task Run(RouterContext context)
        {
            var request = await _requestHelper.GetBody(context.Request);
            var info = _json.Deserialize<VersionValidateModel>(request);
            var body = _requestHelper.GetEmptyResponse();
            
            if (info.Version.Major != "0.12.12.32.20243")
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