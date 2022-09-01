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
    public class MenuLocaleController : Controllers
    {
        public override async Task Run(RouterRequest routerRequest)
        {
            var url = RequestHelper.GetPath(routerRequest.request);
            var locale = LocaleHelper.GetLocaleId(url);

            if (!LocaleService.HasLocale(locale))
            {
                return;
            }
            
            var data = LocaleService.GetMenu(locale);
            var body = new ResponseModel<MenuLocaleModel>(data);
            var json = Json.Serialize(body);
            await SendJson(routerRequest.response, json);
        }
    }
}