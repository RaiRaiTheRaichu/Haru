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

        // locales to add (with name mapping)
        var languages = new Dictionary<string, string>()
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

        // load locales from resources
        EnableResourceLoading();

        foreach (var kvp in languages)
        {
            AddLocaleName(kvp.Key, kvp.Value);
            AddGlobalLocale(kvp.Key);
            AddMenuLocale(kvp.Key);
        }
    }

    private static void EnableResourceLoading()
    {
        Resource.RegisterAssembly(typeof(Mod).Assembly);
    }

    private static void AddLocaleName(string language, string fullname)
    {
        Database.Names.Add(language, fullname);
    }

    private static void AddGlobalLocale(string language)
    {
        var json = Resource.GetText($"Database.Locales.all-{language}.json");
        var body = Json.Deserialize<ResponseModel<GlobalModel>>(json);
        Database.Globals.Add(language, body.Data);
    }

    private static void AddMenuLocale(string language)
    {
        var json = Resource.GetText($"Database.Locales.menu-{language}.json");
        var body = Json.Deserialize<ResponseModel<MenuModel>>(json);
        Database.Menus.Add(language, body.Data);
    }
}