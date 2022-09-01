using System.Collections.Generic;
using Haru.Databases;
using Haru.Models.EFT;
using Haru.Repositories;

namespace Haru.Server.Repositories
{
    public static class LocaleRepository
    {
        public bool HasLocale(string id)
        {
            return LocaleDatabase.Menus.ContainsKey(id);
        }

        public Dictionary<string, string> GetNames()
        {
            return LocaleDatabase.Names;
        }

        public MenuLocaleModel GetMenu(string id)
        {
            return LocaleDatabase.Menus[id];
        }

        public GlobalLocaleModel GetGlobal(string id)
        {
            return LocaleDatabase.Globals[id];
        }

        public string[] GetLocales()
        {
            return LocaleDatabase.Locales;
        }
    }
}