using System.Threading.Tasks;
using Haru.Models;
using Haru.Models.EFT;
using Haru.Models.EFT.Game;
using Haru.Helpers;
using Haru.Http;
using Haru.Services;
using Haru.Utils;

namespace Haru.Controllers
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