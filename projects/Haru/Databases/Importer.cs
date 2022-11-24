using System.Collections.Generic;
using Haru.Models.EFT;
using Haru.Models.EFT.Handbook;
using Haru.Models.EFT.Hideout;
using Haru.Models.EFT.Locale;
using Haru.Models.EFT.Settings;
using Haru.Utils;

namespace Haru.Databases
{
    public class Importer
    {
        private readonly Database _database;
        private readonly Json _json;
        private readonly Resource _resource;

        public Importer()
        {
            _database = Database.Instance;
            _json = new Json();
            _resource = new Resource();
        }

        public void LoadDatabase()
        {
            _resource.RegisterAssembly(typeof(Resource).Assembly);

            LoadLanguages();
            LoadGlobals();
            LoadMenus();
            LoadHideoutSettings();
            LoadScavcases();
            LoadClientSettings();
            LoadTraders();
            LoadHandbookTemplates();
            LoadFiles();
        }

        private void LoadLanguages()
        {
            var json = _resource.GetText("Database.Locales.languages.json");
            var names = _json.Deserialize<Dictionary<string, string>>(json);

            foreach (var kvp in names)
            {
                _database.Names.Add(kvp.Key, kvp.Value);
            }
        }

        private void LoadGlobals()
        {
            foreach (var kvp in _database.Names)
            {
                var lang = kvp.Key;
                var json = _resource.GetText($"Database.Locales.all-{lang}.json");
                var body = _json.Deserialize<ResponseModel<GlobalModel>>(json);
                _database.Globals.Add(lang, body.Data);
            }
        }

        private void LoadMenus()
        {
            foreach (var kvp in _database.Names)
            {
                var lang = kvp.Key;
                var json = _resource.GetText($"Database.Locales.menu-{lang}.json");
                var body = _json.Deserialize<ResponseModel<MenuModel>>(json);
                _database.Menus.Add(lang, body.Data);
            }
        }

        private void LoadHideoutSettings()
        {
            var json = _resource.GetText("Database.Settings.hideout.json");
            var body = _json.Deserialize<ResponseModel<SettingsModel>>(json);
            _database.HideoutSettings = body.Data;
        }

        private void LoadScavcases()
        {
            var json = _resource.GetText("Database.Templates.scavcases.json");
            var body = _json.Deserialize<ResponseModel<ScavcaseModel[]>>(json);
            _database.Scavcases.AddRange(body.Data);
        }

        private void LoadClientSettings()
        {
            var json = _resource.GetText("Database.Settings.client.json");
            var body = _json.Deserialize<ResponseModel<ClientModel>>(json);
            _database.ClientSettings = body.Data;
        }

        private void LoadTraders()
        {
            var json = _resource.GetText("Database.Templates.traders.json");
            var body = _json.Deserialize<ResponseModel<Models.EFT.Trader.TraderModel[]>>(json);
            _database.Traders.AddRange(body.Data);
        }

        private void LoadHandbookTemplates()
        {
            var json = _resource.GetText("Database.Templates.handbook.json");
            var body = _json.Deserialize<ResponseModel<TemplatesModel>>(json);
            _database.HandbookTemplates = body.Data;
        }

        private void LoadFiles()
        {
            var json = _resource.GetText("Database.resxdb.json");
            var files = _json.Deserialize<Dictionary<string, string>>(json);

            foreach (var kvp in files)
            {
                _database.Files.Add(kvp.Key, kvp.Value);
            }
        }
    }
}
