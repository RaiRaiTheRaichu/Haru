using System.Threading.Tasks;
using Haru.Models;
using Haru.Models.EFT;
using Haru.Models.EFT.Settings;
using Haru.Helpers;
using Haru.Http;
using Haru.Services;
using Haru.Utils;

namespace Haru.Controllers
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