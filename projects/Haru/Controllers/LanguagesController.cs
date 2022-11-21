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
    public class LanguagesController : Controller
    {
        public override bool IsMatch(RouterContext context)
        {
            return RequestHelper.GetPath(context.Request)
                == "/client/languages";
        }

        public override async Task Run(RouterContext context)
        {
            var data = LocaleService.GetLanguages();
            var body = new ResponseModel<NameModel[]>(data);
            var json = Json.Serialize(body);
            await SendJson(context, json);
        }
    }
}