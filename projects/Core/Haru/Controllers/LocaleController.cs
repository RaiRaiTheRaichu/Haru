using System.Collections.Generic;
using Haru.Helpers;
using Haru.Http;
using Haru.Models;
using Haru.Models.EFT;
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

        public override void Run(RouterContext context)
        {
            var locale = _localeHelper.FindLocale(context, _format);
            var data = _localeService.GetGlobal(locale);
            var body = new ResponseModel<Dictionary<string, string>>(data);
            var json = _json.Serialize(body);
            SendJson(context, json);
        }
    }
}