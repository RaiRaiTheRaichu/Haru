using System.Collections.Generic;
using Haru.Models.EFT;
using Haru.Models.EFT.Handbook;
using Haru.Models.EFT.Hideout;
using Haru.Models.EFT.Locale;
using Haru.Models.EFT.Settings;
using Haru.Utils;

namespace Haru.Databases
{
    public static class Database
    {
        public static readonly Dictionary<string, string> Names;
        public static readonly Dictionary<string, GlobalModel> Globals;
        public static readonly Dictionary<string, MenuModel> Menus;
        public static SettingsModel HideoutSettings;
        public static readonly List<ScavcaseModel> Scavcases;
        public static ClientModel ClientSettings;
        public static readonly List<Models.EFT.Trader.TraderModel> Traders;
        public static TemplatesModel HandbookTemplates;
        public static readonly Dictionary<string, string> Files;

        static Database()
        {
            Names = new Dictionary<string, string>();
            Globals = new Dictionary<string, GlobalModel>();
            Menus = new Dictionary<string, MenuModel>();
            Scavcases = new List<ScavcaseModel>();
            Traders = new List<Models.EFT.Trader.TraderModel>();
            Files = new Dictionary<string, string>();

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

        private static void LoadLanguages()
        {
            var json = Resource.GetText("db.locale.languages.json");
            var names = Json.Deserialize<Dictionary<string, string>>(json);

            foreach (var name in names)
            {
                Names.Add(name.Key, name.Value);
            }
        }

        private static void LoadGlobals()
        {
            foreach (var name in Names)
            {
                var lang = name.Key;
                var json = Resource.GetText($"db.locale.all-{lang}.json");
                var body = Json.Deserialize<ResponseModel<GlobalModel>>(json);
                Globals.Add(lang, body.Data);
            }
        }

        private static void LoadMenus()
        {
            foreach (var name in Names)
            {
                var lang = name.Key;
                var json = Resource.GetText($"db.locale.menu-{lang}.json");
                var body = Json.Deserialize<ResponseModel<MenuModel>>(json);
                Menus.Add(lang, body.Data);
            }
        }

        private static void LoadHideoutSettings()
        {
            var json = Resource.GetText("db.settings.hideout.json");
            var body = Json.Deserialize<ResponseModel<SettingsModel>>(json);
            HideoutSettings = body.Data;
        }

        private static void LoadScavcases()
        {
            var json = Resource.GetText("db.templates.scavcases.json");
            var body = Json.Deserialize<ResponseModel<ScavcaseModel[]>>(json);
            Scavcases.AddRange(body.Data);
        }

        private static void LoadClientSettings()
        {
            var json = Resource.GetText("db.settings.client.json");
            var body = Json.Deserialize<ResponseModel<ClientModel>>(json);
            ClientSettings = body.Data;
        }

        private static void LoadTraders()
        {
            var json = Resource.GetText("db.templates.traders.json");
            var body = Json.Deserialize<ResponseModel<Models.EFT.Trader.TraderModel[]>>(json);
            Traders.AddRange(body.Data);
        }

        private static void LoadHandbookTemplates()
        {
            var json = Resource.GetText("db.templates.handbook.json");
            var body = Json.Deserialize<ResponseModel<TemplatesModel>>(json);
            HandbookTemplates = body.Data;
        }

        private static void LoadFiles()
        {
            var json = Resource.GetText("db.resxdb.json");
            var files = Json.Deserialize<Dictionary<string, string>>(json);

            foreach (var kvp in files)
            {
                Files.Add(kvp.Key, kvp.Value);
            }
        }
    }
}