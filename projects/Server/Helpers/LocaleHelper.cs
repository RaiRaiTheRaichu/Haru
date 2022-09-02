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
                var name = language.ShortName;

                if (url == string.Format(format, name)
                    && LocaleService.HasLocale(name))
                {
                    return name;
                }
            }

            return null;
        }
    }
}