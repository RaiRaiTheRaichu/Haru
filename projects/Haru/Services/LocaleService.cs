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

        public bool TryGetGlobal(string id, out Dictionary<string, string> locale)
        {
            return _localeRepository.TryGetGlobal(id, out locale);
        }

        public bool TryGetMenu(string id, out MenuModel locale)
        {
            return _localeRepository.TryGetMenu(id, out locale);
        }
    }
}