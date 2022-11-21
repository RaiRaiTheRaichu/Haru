using System.Threading.Tasks;
using Haru.Models;
using Haru.Models.EFT;
using Haru.Models.EFT.Game;
using Haru.Server.Helpers;
using Haru.Server.Http;
using Haru.Server.Services;
using Haru.Utils;

namespace Haru.Server.Controllers
{
    public class CheckVersionController : Controller
    {
        public override bool IsMatch(RouterContext context)
        {
            return RequestHelper.GetPath(context.Request)
                == "/client/checkVersion";
        }

        public override async Task Run(RouterContext context)
        {
            var data = GameService.IsCorrectVersion();
            var body = new ResponseModel<CheckVersionModel>(data);
            var json = Json.Serialize(body);
            await SendJson(context, json);
        }
    }
}