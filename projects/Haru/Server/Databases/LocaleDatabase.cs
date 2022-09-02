// TODO:
// - Add support for multiple languages

using System.Collections.Generic;
using Haru.Models.EFT;
using Haru.Models.EFT.Locale;
using Haru.Utils;

namespace Haru.Server.Databases
{
    public static class LocaleDatabase
    {
        public static readonly Dictionary<string, string> Names;
        public static readonly Dictionary<string, GlobalModel> Globals;

        static LocaleDatabase()
        {
            Names = new Dictionary<string, string>();
            Globals = new Dictionary<string, GlobalModel>();
            
            LoadLanguages();
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

        private static void LoadGlobals()
        {
            var json = Resource.GetText("db.locale.all-en.json");
            var body = Json.Deserialize<ResponseModel<GlobalModel>>(json);
            Globals.Add("en", body.Data);
        }
    }
}