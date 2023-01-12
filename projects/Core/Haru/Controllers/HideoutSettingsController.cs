using System.Threading.Tasks;
using Haru.Models;
using Haru.Models.EFT;
using Haru.Models.EFT.Hideout;
using Haru.Http;
using Haru.Services;

namespace Haru.Controllers
{
    public class HideoutSettingsController : Controller
    {
        private readonly HideoutService _hideoutService;

        public HideoutSettingsController()
        {
            _hideoutService = new HideoutService();
        }

        public override bool IsMatch(RouterContext context)
        {
            return _requestHelper.GetPath(context.Request) == "/client/hideout/settings";
        }

        public override async Task Run(RouterContext context)
        {
            var data = _hideoutService.GetSettings();
            var body = new ResponseModel<SettingsModel>(data);
            var json = _json.Serialize(body);
            await SendJson(context, json);
        }
    }
}