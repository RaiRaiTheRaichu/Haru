using System.Threading.Tasks;
using Haru.Models;
using Haru.Models.EFT;
using Haru.Server.Helpers;
using Haru.Server.Http;
using Haru.Server.Services;
using Haru.Server.Utils;

namespace Haru.Server.Controllers
{
    public class LocaleController : Controller
    {
        public override async Task Run(RouterContext context)
        {
            var url = RequestHelper.GetPath(context.Request);
            var locale = LocaleHelper.GetLocaleId(url);

            if (!LocaleService.HasLocale(locale))
            {
                return;
            }

            var data = LocaleService.GetGlobal(locale);
            var body = new ResponseModel<GlobalLocaleModel>(data);
            var json = Json.Serialize(body);
            await SendJson(context.Response, json);
        }
    }
}