using System.Threading.Tasks;
using Haru.Models;
using Haru.Models.EFT;
using Haru.Server.Helpers;
using Haru.Server.Http;
using Haru.Server.Services;
using Haru.Server.Utils;

namespace Haru.Server.Controllers
{
    public class MenuLocaleController : Controller
    {
        public override async Task Run(RouterContext context)
        {
            var locale = LocaleHelper.FindLocale(
                context, "/client/menu/locale/{0}");

            if (locale == null)
            {
                return;
            }
            
            var data = LocaleService.GetMenu(locale);
            var body = new ResponseModel<MenuLocaleModel>(data);
            var json = Json.Serialize(body);
            await SendJson(context.Response, json);
        }
    }
}