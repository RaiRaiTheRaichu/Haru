using System.Threading.Tasks;
using Haru.Models;
using Haru.Helpers;
using Haru.Http;
using Haru.Utils;

namespace Haru.Controllers
{
    public class MatchOfflineStartController : Controller
    {
        private readonly RequestHelper _requestHelper;
        private readonly Json _json;

        public MatchOfflineStartController()
        {
            _requestHelper = new RequestHelper();
            _json = new Json();
        }

        public override bool IsMatch(RouterContext context)
        {
            return _requestHelper.GetPath(context.Request) == "/client/match/offline/start";
        }

        public override async Task Run(RouterContext context)
        {
            var body = _requestHelper.GetEmptyResponse();
            var json = _json.Serialize(body);
            await SendJson(context, json);
        }
    }
}