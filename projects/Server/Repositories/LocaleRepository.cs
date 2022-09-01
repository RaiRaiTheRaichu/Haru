using System.Collections.Generic;
using Haru.Databases;
using Haru.Models.EFT;
using Haru.Repositories;

namespace Haru.Server.Repositories
{
    public class LocaleRepository : ILocaleRepository
    {
        private readonly ILocaleDatabase _database;

        public LocaleRepository(ILocaleDatabase localeDatabase)
        {
            _database = localeDatabase;
        }

        public bool HasLocale(string id)
        {
            return _database.Menus.ContainsKey(id);
        }

        public Dictionary<string, string> GetNames()
        {
            return _database.Names;
        }

        public MenuLocaleModel GetMenu(string id)
        {
            return _database.Menus[id];
        }

        public GlobalLocaleModel GetGlobal(string id)
        {
            return _database.Globals[id];
        }

        public string[] GetLocales()
        {
            return _database.Locales;
        }
    }
}