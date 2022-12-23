using System.Threading.Tasks;
using Haru.Framework.Models;
using Haru.Models.EFT;
using Haru.Models.EFT.Settings;
using Haru.Framework.Helpers;
using Haru.Framework.Http;
using Haru.Services;
using Haru.Framework.Utils;

namespace Haru.Controllers
{
    public class SettingsController : Controller
    {
        private readonly RequestHelper _requestHelper;
        private readonly Json _json;
        private readonly SettingsService _settingsService;

        public SettingsController()
        {
            _requestHelper = new RequestHelper();
            _json = new Json();
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