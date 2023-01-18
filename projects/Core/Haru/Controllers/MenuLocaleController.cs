using Haru.Helpers;
using Haru.Models;
using Haru.Models.EFT;
using Haru.Models.EFT.Locale;
using Haru.Http;
using Haru.Services;

namespace Haru.Controllers
{
    public class MenuLocaleController : Controller
    {
        private readonly LocaleHelper _localeHelper;
        private readonly LocaleService _localeService;
        private const string _format = "/client/menu/locale/{0}";

        public MenuLocaleController()
        {
            _localeHelper = new LocaleHelper();
            _localeService = new LocaleService();
        }

        public override void Run(RouterContext context)
        {
            var locale = _localeHelper.FindLocale(context, _format);
            var data = _localeService.GetMenu(locale);
            var body = new ResponseModel<MenuModel>(data);
            var json = _json.Serialize(body);
            SendJson(context, json);
        }
    }
}