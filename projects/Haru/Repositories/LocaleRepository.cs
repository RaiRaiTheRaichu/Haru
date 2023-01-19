using System.Collections.Generic;
using Haru.Databases;
using Haru.Models.EFT.Locale;

namespace Haru.Repositories
{
    public class LocaleRepository
    {
        private readonly Database _database;

        public LocaleRepository()
        {
            _database = Database.Instance;
        }

        public Dictionary<string, string> GetNames()
        {
            return _database.Names;
        }

        public bool TryGetGlobal(string id, out Dictionary<string, string> locale)
        {
            return _database.Globals.TryGetValue(id, out locale);
        }

        public bool TryGetMenu(string id, out MenuModel locale)
        {
            return _database.Menus.TryGetValue(id, out locale);
        }
    }
}