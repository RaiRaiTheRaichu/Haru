using System.Threading.Tasks;
using Haru.Models;
using Haru.Models.EFT;
using Haru.Models.EFT.Locale;
using Haru.Helpers;
using Haru.Http;
using Haru.Services;
using Haru.Utils;

namespace Haru.Controllers
{
    public class LocaleController : Controller
    {
        private const string _format = "/client/locale/{0}";

        public override bool IsMatch(RouterContext context)
        {
            return LocaleHelper.FindLocale(context, _format) != null;
        }

        public override async Task Run(RouterContext context)
        {
            var locale = LocaleHelper.FindLocale(context, _format);
            var data = LocaleService.GetGlobal(locale);
            var body = new ResponseModel<GlobalModel>(data);
            var json = Json.Serialize(body);
            await SendJson(context, json);
        }
    }
}