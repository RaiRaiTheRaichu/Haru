using System.Threading.Tasks;
using Haru.Models;
using Haru.Models.EFT;
using Haru.Models.EFT.Locale;
using Haru.Server.Helpers;
using Haru.Server.Http;
using Haru.Server.Services;
using Haru.Utils;

namespace Haru.Server.Controllers
{
    public class MenuController : Controller
    {
        private const string _format = "/client/menu/locale/{0}";

        public override bool IsMatch(RouterContext context)
        {
            return LocaleHelper.FindLocale(context, _format) == null;
        }

        public override async Task Run(RouterContext context)
        {
            var locale = LocaleHelper.FindLocale(context, _format);
            var data = LocaleService.GetMenu(locale);
            var body = new ResponseModel<MenuModel>(data);
            var json = Json.Serialize(body);
            await SendJson(context, json);
        }
    }
}