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

        public static bool HasLocale(string id)
        {
            return _localeRepository.HasLocale(id);
        }

        public static Dictionary<string, string> GetNames()
        {
            return _localeRepository.GetNames();
        }

        public static GlobalModel GetGlobal(string id)
        {
            return _localeRepository.GetGlobal(id);
        }

        public static MenuModel GetMenu(string id)
        {
            return _localeRepository.GetMenu(id);
        }

        public static void AddName(string id, string value)
        {
            _database.Names.Add(id, value);
        }

        public static void AddGlobal(string id, GlobalModel value)
        {
            _database.Globals.Add(id, value);
        }

        public static void AddMenu(string id, MenuModel value)
        {
            _database.Menus.Add(id, value);
        }
    }
}
