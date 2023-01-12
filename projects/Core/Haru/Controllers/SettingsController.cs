using System.Threading.Tasks;
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

        public override bool IsMatch(RouterContext context)
        {
            return _requestHelper.GetPath(context.Request) == "/client/settings";
        }

        public override async Task Run(RouterContext context)
        {
            var data = _settingsService.GetClientSettings();
            var body = new ResponseModel<ClientModel>(data);
            var json = _json.Serialize(body);
            await SendJson(context, json);
        }
    }
}