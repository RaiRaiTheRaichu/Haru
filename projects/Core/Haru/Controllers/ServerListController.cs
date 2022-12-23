using System.Threading.Tasks;
using Haru.Framework.Models;
using Haru.Models.EFT;
using Haru.Framework.Helpers;
using Haru.Framework.Http;
using Haru.Services;
using Haru.Framework.Utils;

namespace Haru.Controllers
{
    public class ServerListController : Controller
    {
        private readonly RequestHelper _requestHelper;
        private readonly Json _json;
        private readonly ServerService _serverService;

        public ServerListController()
        {
            _requestHelper = new RequestHelper();
            _json = new Json();
            _serverService = new ServerService();
        }

        public override bool IsMatch(RouterContext context)
        {
            return _requestHelper.GetPath(context.Request) == "/client/server/list";
        }

        public override async Task Run(RouterContext context)
        {
            var data = _serverService.GetServers();
            var body = new ResponseModel<ServerInfoModel[]>(data);
            var json = _json.Serialize(body);
            await SendJson(context, json);
        }
    }
}