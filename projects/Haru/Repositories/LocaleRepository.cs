using System.Collections.Generic;
using Haru.Models.EFT.Locale;
using Haru.Databases;

namespace Haru.Repositories
{
    public static class LocaleRepository
    {
        public static bool HasLocale(string id)
        {
            return Database.Globals.ContainsKey(id);
        }

        public static Dictionary<string, string> GetNames()
        {
            return Database.Names;
        }

        public static GlobalModel GetGlobal(string id)
        {
            return Database.Globals[id];
        }

        public static MenuModel GetMenu(string id)
        {
            return Database.Menus[id];
        }
    }
}