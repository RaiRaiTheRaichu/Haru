using System.Threading.Tasks;
using Haru.Server.Events;
using Haru.Server.Http;
using Haru.Models.EFT;
using Haru.Server.Services;
using Haru.Server.Utils;

namespace Haru.Server.Controllers
{
    public class LanguagesController : Controller
    {
        public override async Task Run(RouterRequest routerRequest)
        {
            if (!routerRequest.request.Url.LocalPath.Equals("/client/languages"))
            {
                return;
            }

            var data = LocaleService.GetLanguages();
            var body = new ResponseModel<NameLocaleModel[]>(data);
            var json = Json.Serialize(body);
            await SendJson(routerRequest.response, json);
        }
    }
}