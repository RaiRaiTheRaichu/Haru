using System.Threading.Tasks;
using Haru.Framework.Models;
using Haru.Models.EFT;
using Haru.Framework.Http;
using Haru.Services;

namespace Haru.Controllers
{
    public class ServerListController : Controller
    {
        private readonly ServerService _serverService;

        public ServerListController()
        {
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