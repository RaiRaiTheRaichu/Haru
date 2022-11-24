using System.Collections.Generic;
using Haru.ModApi;
using Haru.Models.EFT;
using Haru.Models.EFT.Locale;

public class Mod
{
    public static void Run()
    {
        LogApi.Write("Loading Senko.Langpack");

        // locales to add (with name mapping)
        var languages = new Dictionary<string, string>()
        {
            // Key     Value
            { "ch",    "Chinese"        },
            { "cz",    "Czech"          },
            { "hu",    "Hungarian"      },
            { "it",    "Italian"        },
            { "jp",    "Japanese"       },
            { "kr",    "Korean"         },
            { "pl",    "Polish"         },
            { "po",    "Portugal"       },
            { "sk",    "Slovak"         },
            { "es",    "Spanish"        },
            { "es-mx", "Spanish Mexico" },
            { "tu",    "Turkish"        }
        };

        // load locales from resources
        ResourceApi.EnableResourceLoading(typeof(Mod).Assembly);

        foreach (var kvp in languages)
        {
            LocaleApi.AddName(kvp.Key, kvp.Value);
            AddGlobalLocale(kvp.Key);
            AddMenuLocale(kvp.Key);
        }
    }

    private static void AddGlobalLocale(string id)
    {
        var json = ResourceApi.GetText($"Database.Locales.all-{id}.json");
        var body = JsonApi.Deserialize<ResponseModel<GlobalModel>>(json);
        LocaleApi.AddGlobal(id, body.Data);
    }

    private static void AddMenuLocale(string id)
    {
        var json = ResourceApi.GetText($"Database.Locales.menu-{id}.json");
        var body = JsonApi.Deserialize<ResponseModel<MenuModel>>(json);
        LocaleApi.AddMenu(id, body.Data);
    }
}