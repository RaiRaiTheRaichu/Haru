using System.Collections.Generic;
using Haru.Databases;
using Haru.Models.EFT.Locale;
using Haru.Repositories;

namespace Haru.ModApi
{
    public static class LocaleApi
    {
        public static bool HasLocale(string id)
        {
            return LocaleRepository.HasLocale(id);
        }

        public static Dictionary<string, string> GetNames()
        {
            return LocaleRepository.GetNames();
        }

        public static GlobalModel GetGlobal(string id)
        {
            return LocaleRepository.GetGlobal(id);
        }

        public static MenuModel GetMenu(string id)
        {
            return LocaleRepository.GetMenu(id);
        }

        public static void AddName(string id, string value)
        {
            Database.Names.Add(id, value);
        }

        public static void AddGlobal(string id, GlobalModel value)
        {
            Database.Globals.Add(id, value);
        }

        public static void AddMenu(string id, MenuModel value)
        {
            Database.Menus.Add(id, value);
        }
    }
}
