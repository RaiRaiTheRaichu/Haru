using Haru.Models;
using Haru.Services;

namespace Haru.Helpers
{
    public class LocaleHelper
    {
        private readonly RequestHelper _requestHelper;
        private readonly LocaleService _localeService;

        public LocaleHelper()
        {
            _requestHelper = new RequestHelper();
            _localeService = new LocaleService();
        }

        public string FindLocale(RouterContext context, string format)
        {
            var url = _requestHelper.GetPath(context.Request);
            var languages = _localeService.GetLanguages();

            foreach (var language in languages)
            {
                if (url == string.Format(format, language.ShortName))
                {
                    return language.ShortName;
                }
            }

            return null;
        }
    }
}