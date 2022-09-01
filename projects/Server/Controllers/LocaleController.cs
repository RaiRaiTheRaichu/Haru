using System.Collections.Generic;
using System.Threading.Tasks;
using Haru.Server.Events;
using Haru.Server.Helpers;
using Haru.Server.Http;
using Haru.Models.EFT;
using Haru.Server.Services;
using Haru.Server.Utils;

namespace Haru.Server.Controllers
{
    public class LocaleController : Controller
    {
        public override async Task Run(RouterRequest routerRequest)
        {
            var url = RequestHelper.GetPath(routerRequest.request);
            var locale = LocaleHelper.GetLocaleId(url);

            if (!LocaleService.HasLocale(locale))
            {
                // throw exception
                return;
            }

            var data = LocaleService.GetGlobal(locale);
            var body = new ResponseModel<GlobalLocaleModel>(data);
            var json = Json.Serialize(body);
            await SendJson(routerRequest.response, json);
        }
    }
}