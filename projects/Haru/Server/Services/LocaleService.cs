using Haru.Models.EFT.Locale;
using Haru.Server.Repositories;

namespace Haru.Server.Services
{
    public static class LocaleService
    {
        public static bool HasLocale(string id)
        {
            return LocaleRepository.HasLocale(id);
        }

        public static NameModel[] GetLanguages()
        {
            var names = LocaleRepository.GetNames();
            var data = new NameModel[names.Count];
            var i = 0;

            foreach (var kvp in names)
            {
                data[i++] = new NameModel()
                {
                    ShortName = kvp.Key,
                    Name = kvp.Value
                };
            }

            return data;
        }

        public static GlobalModel GetGlobal(string id)
        {
            return LocaleRepository.GetGlobal(id);
        }

        public static MenuModel GetMenu(string id)
        {
            return LocaleRepository.GetMenu(id);
        }
    }
}