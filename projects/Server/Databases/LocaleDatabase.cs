using System.Collections.Generic;
using Haru.Models.EFT;
using Haru.Resources;
using Haru.Server.Utils;

namespace Haru.Server.Databases
{
    public class LocaleDatabase
    {
        public Dictionary<string, string> Names { get; set; }
        public Dictionary<string, MenuLocaleModel> Menus { get; set; }
        public Dictionary<string, GlobalLocaleModel> Globals { get; set; }

        public string[] Locales { get; private set; }

        public LocaleDatabase()
        {
            Locales = new string[] { };
            Names = new Dictionary<string, string>();
            Menus = new Dictionary<string, MenuLocaleModel>();
            Globals = new Dictionary<string, GlobalLocaleModel>();
        }

        public async Task Initialize()
        {
            await LoadLanguages();
            await LoadMenus();
            await LoadGlobals();
        }

        private void LoadLanguages()
        {
            var json = ResourceHandler.GetText("db.locale.lang.json");
            var names = Json.Deserialize<Dictionary<string, string>>(json);
            
            foreach (var name in names)
            {
                Names.add(name.key, name.Value);
            }
        }

        private void LoadMenus()
        {
            var json = ResourceHandler.GetText("db.locale.menu-en.json");
            var body = Json.Deserialize<ResponseModel<MenuLocaleModel>>(json);
            Menus.Add("en", body.Data);
        }

        private void LoadGlobals()
        {
            var json = ResourceHandler.GetText("db.locale.all-en.json");
            var body = Json.Deserialize<ResponseModel<GlobalLocaleModel>>(json);
            Globals.Add("en", body.Data);
        }
    }
}