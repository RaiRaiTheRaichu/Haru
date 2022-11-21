using System.Threading.Tasks;
using Haru.Models;
using Haru.Models.EFT;
using Haru.Models.EFT.Trader;
using Haru.Helpers;
using Haru.Http;
using Haru.Services;
using Haru.Utils;

namespace Haru.Controllers
{
    public class TraderSettingsController : Controller
    {
        public override bool IsMatch(RouterContext context)
        {
            return RequestHelper.GetPath(context.Request)
                == "/client/trading/api/traderSettings";
        }

        public override async Task Run(RouterContext context)
        {
            var data = TraderService.GetTraders();
            var body = new ResponseModel<TraderModel[]>(data);
            var json = Json.Serialize(body);
            await SendJson(context, json);
        }
    }
}