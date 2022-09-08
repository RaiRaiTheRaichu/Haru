using System.Threading.Tasks;
using Haru.Models;
using Haru.Models.EFT;
using Haru.Models.EFT.Settings;
using Haru.Server.Helpers;
using Haru.Server.Http;
using Haru.Server.Services;
using Haru.Utils;

namespace Haru.Server.Controllers
{
    public class SettingsController : Controller
    {
        public override bool IsMatch(RouterContext context)
        {
            return RequestHelper.GetPath(context.Request)
                == "/client/settings";
        }

        public override async Task Run(RouterContext context)
        {
            var data = SettingsService.GetClientSettings();
            var body = new ResponseModel<ClientModel>(data);
            var json = Json.Serialize(body);
            await SendJson(context, json);
        }
    }
}