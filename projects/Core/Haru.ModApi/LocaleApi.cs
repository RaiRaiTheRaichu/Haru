using System.Collections.Generic;
using Haru.Databases;
using Haru.Models.EFT.Locale;
using Haru.Repositories;

namespace Haru.ModApi
{
    public static class LocaleApi
    {
        private static readonly Database _database;
        private static readonly LocaleRepository _localeRepository;

        static LocaleApi()
        {
            _database = Database.Instance;
            _localeRepository = new LocaleRepository();
        }

        public static Dictionary<string, string> GetNames()
        {
            return _localeRepository.GetNames();
        }

        public static bool TryGetGlobal(string id, out Dictionary<string, string> locale)
        {
            return _localeRepository.TryGetGlobal(id, out locale);
        }

        public static bool TryGetMenu(string id, out MenuModel locale)
        {
            return _localeRepository.TryGetMenu(id, out locale);
        }

        public static void AddName(string id, string value)
        {
            _database.Names.Add(id, value);
        }

        public static void AddGlobal(string id, Dictionary<string, string> value)
        {
            _database.Globals.Add(id, value);
        }

        public static void AddMenu(string id, MenuModel value)
        {
            _database.Menus.Add(id, value);
        }
    }
}
