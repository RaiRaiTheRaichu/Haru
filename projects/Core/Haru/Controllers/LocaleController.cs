using System.Collections.Generic;
using System.Threading.Tasks;
using Haru.Models;
using Haru.Helpers;
using Haru.Models.EFT;
using Haru.Models.EFT.Locale;
using Haru.Http;
using Haru.Services;

namespace Haru.Controllers
{
    public class LocaleController : Controller
    {
        private readonly LocaleHelper _localeHelper;
        private readonly LocaleService _localeService;
        private const string _format = "/client/locale/{0}";

        public LocaleController()
        {
            _localeHelper = new LocaleHelper();
            _localeService = new LocaleService();
        }

        public override bool IsMatch(RouterContext context)
        {
            return _localeHelper.FindLocale(context, _format) != null;
        }

        public override async Task Run(RouterContext context)
        {
            var locale = _localeHelper.FindLocale(context, _format);
            var data = _localeService.GetGlobal(locale);
            var body = new ResponseModel<Dictionary<string, string>>(data);
            var json = _json.Serialize(body);
            await SendJson(context, json);
        }
    }
}