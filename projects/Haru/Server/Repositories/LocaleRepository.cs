using System.Collections.Generic;
using Haru.Server.Databases;
using Haru.Models.EFT.Locale;
using Haru.Server.Repositories;

namespace Haru.Server.Repositories
{
    public static class LocaleRepository
    {
        public static bool HasLocale(string id)
        {
            return LocaleDatabase.Globals.ContainsKey(id);
        }

        public static Dictionary<string, string> GetNames()
        {
            return LocaleDatabase.Names;
        }

        public static GlobalModel GetGlobal(string id)
        {
            return LocaleDatabase.Globals[id];
        }
    }
}