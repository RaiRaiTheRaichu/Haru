using System.Collections.Generic;
using Haru.Helpers;
using Haru.Http;
using Haru.Models;
using Haru.Models.EFT;
using Haru.Services;
using Haru.Utils;

namespace Haru.Controllers
{
    public class LocaleController : Controller
    {
        private readonly Log _log;
        private readonly LocaleHelper _localeHelper;
        private readonly LocaleService _localeService;
        private const string _format = "/client/locale/{0}";

        public LocaleController()
        {
            _log = new Log();
            _localeHelper = new LocaleHelper();
            _localeService = new LocaleService();
        }

        public override void Run(RouterContext context)
        {
            var localeId = _localeHelper.FindLocale(context, _format);

            if (_localeService.TryGetGlobal(localeId, out var locale))
            {
                var body = new ResponseModel<Dictionary<string, string>>(locale);
                var json = _json.Serialize(body);
                SendJson(context, json);
            }
            else
            {
                _log.Write($"Global locale not found for {localeId}");
                context.Response.Close();
            }
        }
    }
}