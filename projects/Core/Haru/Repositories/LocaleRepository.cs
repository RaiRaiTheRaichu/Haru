using System.Collections.Generic;
using Haru.Models.EFT.Locale;
using Haru.Databases;

namespace Haru.Repositories
{
    public class LocaleRepository
    {
        private readonly Database _database;

        public LocaleRepository()
        {
            _database = Database.Instance;
        }

        public bool HasLocale(string id)
        {
            return _database.Globals.ContainsKey(id);
        }

        public Dictionary<string, string> GetNames()
        {
            return _database.Names;
        }

        public Dictionary<string, string> GetGlobal(string id)
        {
            return _database.Globals[id];
        }

        public MenuModel GetMenu(string id)
        {
            return _database.Menus[id];
        }
    }
}