using System.Threading.Tasks;
using Haru.Server.Events;
using Haru.Server.Http;
using Haru.Models.EFT;
using Haru.Server.Services;
using Haru.Server.Utils;

namespace Haru.Server.Controllers
{
    public class ServerListController : Controller
    {
        public override async Task Run(RouterContext context)
        {
            if (!context.Request.Url.LocalPath
                .Equals("/client/server/list"))
            {
                return;
            }

            var data = ServerService.GetServers();
            var body = new ResponseModel<ServerModel[]>(data);
            var json = Json.Serialize(body);
            await SendJson(context.response, json);
        }
    }
}