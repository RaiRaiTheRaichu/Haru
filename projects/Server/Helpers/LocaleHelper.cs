using System.Linq;

namespace Haru.Server.Helpers
{
    public static class LocaleHelper
    {
        public static string GetLocaleId(string url)
        {
            return url.Split('/').Last();
        }
    }
}