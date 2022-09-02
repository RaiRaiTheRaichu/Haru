using System.Collections.Generic;
using Haru.Server.Databases;
using Haru.Models.EFT;
using Haru.Server.Repositories;

namespace Haru.Server.Repositories
{
    public static class LocaleRepository
    {
        public static bool HasLocale(string id)
        {
            return LocaleDatabase.Menus.ContainsKey(id);
        }

        public static Dictionary<string, string> GetNames()
        {
            return LocaleDatabase.Names;
        }

        public static MenuLocaleModel GetMenu(string id)
        {
            return LocaleDatabase.Menus[id];
        }

        public static GlobalLocaleModel GetGlobal(string id)
        {
            return LocaleDatabase.Globals[id];
        }
    }
}