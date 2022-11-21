using System.Threading.Tasks;
using Haru.Models;
using Haru.Models.EFT;
using Haru.Server.Helpers;
using Haru.Server.Http;
using Haru.Server.Services;
using Haru.Utils;

namespace Haru.Server.Controllers
{
    public class ServerListController : Controller
    {
        public override bool IsMatch(RouterContext context)
        {
            return RequestHelper.GetPath(context.Request)
                == "/client/server/list";
        }

        public override async Task Run(RouterContext context)
        {
            var data = ServerService.GetServers();
            var body = new ResponseModel<ServerInfoModel[]>(data);
            var json = Json.Serialize(body);
            await SendJson(context, json);
        }
    }
}