using System.Threading.Tasks;
using Haru.Framework.Models;
using Haru.Models.EFT;
using Haru.Models.EFT.Locale;
using Haru.Framework.Helpers;
using Haru.Framework.Http;
using Haru.Services;
using Haru.Framework.Utils;

namespace Haru.Controllers
{
    public class LanguagesController : Controller
    {
        private readonly RequestHelper _requestHelper;
        private readonly Json _json;
        private readonly LocaleService _localeService;

        public LanguagesController()
        {
            _requestHelper = new RequestHelper();
            _json = new Json();
            _localeService = new LocaleService();
        }

        public override bool IsMatch(RouterContext context)
        {
            return _requestHelper.GetPath(context.Request) == "/client/languages";
        }

        public override async Task Run(RouterContext context)
        {
            var data = _localeService.GetLanguages();
            var body = new ResponseModel<NameModel[]>(data);
            var json = _json.Serialize(body);
            await SendJson(context, json);
        }
    }
}