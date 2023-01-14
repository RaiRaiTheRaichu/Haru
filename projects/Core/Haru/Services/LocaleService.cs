using System.Collections.Generic;
using Haru.Models.EFT.Locale;
using Haru.Repositories;

namespace Haru.Services
{
    public class LocaleService
    {
        private readonly LocaleRepository _localeRepository;

        public LocaleService()
        {
            _localeRepository = new LocaleRepository();
        }

        public bool HasLocale(string id)
        {
            return _localeRepository.HasLocale(id);
        }

        public NameModel[] GetLanguages()
        {
            var names = _localeRepository.GetNames();
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

        public Dictionary<string, string> GetGlobal(string id)
        {
            return _localeRepository.GetGlobal(id);
        }

        public MenuModel GetMenu(string id)
        {
            return _localeRepository.GetMenu(id);
        }
    }
}