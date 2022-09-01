using Haru.Models.EFT;
using Haru.Repositories;
using Haru.Server.Services;

namespace Haru.Server.Services
{
    public static class LocaleService
    {
        public bool HasLocale(string id)
        {
            return LocaleRepository.HasLocale(id);
        }

        public NameLocaleModel[] GetLanguages()
        {
            var names = LocaleRepository.GetNames();
            var data = new NameLocaleModel[names.Count];
            var i = 0;

            foreach (var kvp in names)
            {
                data[i++] = new NameLocaleModel()
                {
                    ShortName = kvp.Key,
                    Name = kvp.Value
                };
            }

            return data;
        }

        public MenuLocaleModel GetMenu(string id)
        {
            return LocaleRepository.GetMenu(id);
        }

        public GlobalLocaleModel GetGlobal(string id)
        {
            return LocaleRepository.GetGlobal(id);
        }

        public string[] GetLocales()
        {
            return LocaleRepository.GetLocales();
        }
    }
}