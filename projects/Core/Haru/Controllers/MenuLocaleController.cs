using System.Threading.Tasks;
using Haru.Helpers;
using Haru.Framework.Models;
using Haru.Models.EFT;
using Haru.Models.EFT.Locale;
using Haru.Framework.Helpers;
using Haru.Framework.Http;
using Haru.Services;
using Haru.Framework.Utils;

namespace Haru.Controllers
{
    public class MenuLocaleController : Controller
    {
        private readonly LocaleHelper _localeHelper;
        private readonly RequestHelper _requestHelper;
        private readonly Json _json;
        private readonly LocaleService _localeService;
        private const string _format = "/client/menu/locale/{0}";

        public MenuLocaleController()
        {
            _localeHelper = new LocaleHelper();
            _requestHelper = new RequestHelper();
            _json = new Json();
            _localeService = new LocaleService();
        }

        public override bool IsMatch(RouterContext context)
        {
            return _localeHelper.FindLocale(context, _format) != null;
        }

        public override async Task Run(RouterContext context)
        {
            var locale = _localeHelper.FindLocale(context, _format);
            var data = _localeService.GetMenu(locale);
            var body = new ResponseModel<MenuModel>(data);
            var json = _json.Serialize(body);
            await SendJson(context, json);
        }
    }
}