using System.Threading.Tasks;
using Haru.Models;
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
            return _requestHelper.GetPath(context.Request)
                == "/client/game/version/validate";
        }

        public override async Task Run(RouterContext context)
        {
            var body = _requestHelper.GetEmptyResponse();
            var json = _json.Serialize(body);
            await SendJson(context, json);
        }
    }
}