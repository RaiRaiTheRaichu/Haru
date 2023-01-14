using Haru.Models;
using Haru.Models.EFT;
using Haru.Models.EFT.Locale;
using Haru.Http;
using Haru.Services;

namespace Haru.Controllers
{
    public class LanguagesController : Controller
    {
        private readonly LocaleService _localeService;

        public LanguagesController()
        {
            _localeService = new LocaleService();
        }

        public override bool IsMatch(RouterContext context)
        {
            return _requestHelper.GetPath(context.Request) == "/client/languages";
        }

        public override void Run(RouterContext context)
        {
            var data = _localeService.GetLanguages();
            var body = new ResponseModel<NameModel[]>(data);
            var json = _json.Serialize(body);
            SendJson(context, json);
        }
    }
}