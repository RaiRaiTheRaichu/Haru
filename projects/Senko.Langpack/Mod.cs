using System.Collections.Generic;
using Haru.Databases;
using Haru.Models.EFT;
using Haru.Models.EFT.Locale;
using Haru.Utils;

public class Mod
{
    public static void Run()
    {
        Log.Write("Loading Senko.Langpack");

        // allow mod to load embedded resources
        Resource.RegisterAssembly(typeof(Mod).Assembly);

        // locales to add (with name mapping)
        var names = new Dictionary<string, string>()
        {
            { "ch", "Chinese" },
            { "cz", "Czech" },
            { "hu", "Hungarian" },
            { "it", "Italian" },
            { "jp", "Japanese" },
            { "kr", "Korean" },
            { "pl", "Polish" },
            { "po", "Portugal" },
            { "sk", "Slovak" },
            { "es", "Spanish" },
            { "es-mx", "Spanish Mexico" },
            { "tu", "Turkish" }
        };

        // add language names to database
        foreach (var kvp in names)
        {
            Database.Names.Add(kvp.Key, kvp.Value);
        }
        
        // add global locales from game dump
        foreach (var kvp in names)
        {
            var lang = kvp.Key;
            var json = Resource.GetText($"Database.Locales.all-{lang}.json");
            var body = Json.Deserialize<ResponseModel<GlobalModel>>(json);
            Database.Globals.Add(lang, body.Data);
        }

        // add menu locales from game dump
        foreach (var kvp in names)
        {
            var lang = kvp.Key;
            var json = Resource.GetText($"Database.Locales.menu-{lang}.json");
            var body = Json.Deserialize<ResponseModel<MenuModel>>(json);
            Database.Menus.Add(lang, body.Data);
        }
    }
}