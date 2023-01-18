using Haru.Http;
using Haru.Models;
using Haru.Models.EFT;
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

        public override void Run(RouterContext context)
        {
            var data = _serverService.GetServers();
            var body = new ResponseModel<ServerInfoModel[]>(data);
            var json = _json.Serialize(body);
            SendJson(context, json);
        }
    }
}