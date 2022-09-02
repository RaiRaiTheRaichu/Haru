using System.Collections.Generic;
using Haru.Models.EFT;
using Haru.Server.Utils;

namespace Haru.Server.Databases
{
    public static class LocaleDatabase
    {
        public static readonly Dictionary<string, string> Names;
        public static readonly Dictionary<string, MenuLocaleModel> Menus;
        public static readonly Dictionary<string, GlobalLocaleModel> Globals;

        static LocaleDatabase()
        {
            Names = new Dictionary<string, string>();
            Menus = new Dictionary<string, MenuLocaleModel>();
            Globals = new Dictionary<string, GlobalLocaleModel>();
            
            LoadLanguages();
            LoadMenus();
            LoadGlobals();
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

        private static void LoadMenus()
        {
            var json = Resource.GetText("db.locale.menu-en.json");
            var body = Json.Deserialize<ResponseModel<MenuLocaleModel>>(json);
            Menus.Add("en", body.Data);
        }

        private static void LoadGlobals()
        {
            var json = Resource.GetText("db.locale.all-en.json");
            var body = Json.Deserialize<ResponseModel<GlobalLocaleModel>>(json);
            Globals.Add("en", body.Data);
        }
    }
}