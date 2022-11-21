using System.Threading.Tasks;
using Haru.Models;
using Haru.Models.EFT;
using Haru.Models.EFT.Hideout;
using Haru.Helpers;
using Haru.Http;
using Haru.Services;
using Haru.Utils;

namespace Haru.Controllers
{
    public class HideoutSettingsController : Controller
    {
        public override bool IsMatch(RouterContext context)
        {
            return RequestHelper.GetPath(context.Request)
                == "/client/hideout/settings";
        }

        public override async Task Run(RouterContext context)
        {
            var data = HideoutService.GetSettings();
            var body = new ResponseModel<SettingsModel>(data);
            var json = Json.Serialize(body);
            await SendJson(context, json);
        }
    }
}