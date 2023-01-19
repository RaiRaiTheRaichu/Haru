using Haru.Models.EFT.Hideout;
using Haru.Http;
using Haru.Models;
using Haru.Models.EFT;
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

        public override void Run(RouterContext context)
        {
            var data = _hideoutService.GetSettings();
            var body = new ResponseModel<SettingsModel>(data);
            var json = _json.Serialize(body);
            SendJson(context, json);
        }
    }
}