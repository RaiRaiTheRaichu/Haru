using System.Collections.Generic;
using Haru.Databases;
using Haru.Models.EFT;
using Haru.Models.EFT.Handbook;
using Haru.Models.EFT.Hideout;
using Haru.Models.EFT.Locale;
using Haru.Models.EFT.Location;
using Haru.Models.EFT.Settings;
using Haru.Utils;

namespace Senko.EftData
{
    public class Mod
    {
        private readonly Json _json;
        private readonly Log _log;
        private readonly Resource _resource;
        private readonly Database _database;

        public Mod()
        {
            _json = new Json();
            _log = new Log();
            _resource = new Resource();
            _database = Database.Instance;
        }

        public void Run()
        {
            _log.Write("Loading Senko.EftData");

            _resource.RegisterAssembly(typeof(Mod).Assembly);

            LoadLanguages();
            LoadHideoutSettings();
            LoadScavcases();
            LoadClientSettings();
            LoadTraders();
            LoadHandbookTemplates();
            LoadWorldMap();
            LoadFiles();
        }

        private void LoadLanguages()
        {
            var json = _resource.GetText("Database.Locales.languages.json");
            var names = _json.Deserialize<Dictionary<string, string>>(json);

            foreach (var kvp in names)
            {
                // add language name
                _database.Names.Add(kvp.Key, kvp.Value);

                // add language data
                LoadGlobalLocale(kvp.Key);
                LoadMenuLocale(kvp.Key);
            }
        }

        private void LoadGlobalLocale(string lang)
        {
            var json = _resource.GetText($"Database.Locales.all-{lang}.json");
            var body = _json.Deserialize<ResponseModel<Dictionary<string, string>>>(json);
            _database.Globals.Add(lang, body.Data);
        }

        private void LoadMenuLocale(string lang)
        {
            var json = _resource.GetText($"Database.Locales.menu-{lang}.json");
            var body = _json.Deserialize<ResponseModel<MenuModel>>(json);
            _database.Menus.Add(lang, body.Data);
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
            var body = _json.Deserialize<ResponseModel<Haru.Models.EFT.Trader.TraderModel[]>>(json);
            _database.Traders.AddRange(body.Data);
        }

        private void LoadHandbookTemplates()
        {
            var json = _resource.GetText("Database.Templates.handbook.json");
            var body = _json.Deserialize<ResponseModel<TemplatesModel>>(json);
            _database.HandbookTemplates = body.Data;
        }

        private void LoadWorldMap()
        {
            var json = _resource.GetText("Database.Templates.locations.json");
            var body = _json.Deserialize<ResponseModel<WorldMapModel>>(json);
            _database.WorldMap = body.Data;
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