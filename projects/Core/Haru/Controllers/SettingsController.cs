using Haru.Models;
using Haru.Models.EFT;
using Haru.Models.EFT.Settings;
using Haru.Http;
using Haru.Services;

namespace Haru.Controllers
{
    public class SettingsController : Controller
    {
        private readonly SettingsService _settingsService;

        public SettingsController()
        {
            _settingsService = new SettingsService();
        }

        public override void Run(RouterContext context)
        {
            var data = _settingsService.GetClientSettings();
            var body = new ResponseModel<ClientModel>(data);
            var json = _json.Serialize(body);
            SendJson(context, json);
        }
    }
}