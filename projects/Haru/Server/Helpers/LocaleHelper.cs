using Haru.Models;
using Haru.Server.Services;

namespace Haru.Server.Helpers
{
    public static class LocaleHelper
    {
        public static string FindLocale(RouterContext context, string format)
        {
            var url = RequestHelper.GetPath(context.Request);
            var languages = LocaleService.GetLanguages();

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