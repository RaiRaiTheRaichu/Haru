using System.Collections.Generic;
using Haru.ModApi;
using Haru.Models.EFT;
using Haru.Models.EFT.Locale;

namespace Senko.LangPack
{
    public class Mod
    {
        public static void Run()
        {
            LogApi.Write("Loading Senko.Langpack");

            // allow loading of embeddded files
            ResourceApi.EnableResourceLoading(typeof(Mod).Assembly);

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
            foreach (var kvp in languages)
            {
                var langId = kvp.Key;
                var langName = kvp.Value;

                // register language
                LocaleApi.AddName(langId, langName);

                // add global locale
                var globalJson = ResourceApi.GetText($"Database.Locales.all-{langId}.json");
                var globalBody = JsonApi.Deserialize<ResponseModel<Dictionary<string, string>>>(globalJson);
                LocaleApi.AddGlobal(langId, globalBody.Data);

                // add menu locale
                var menuJson = ResourceApi.GetText($"Database.Locales.menu-{langId}.json");
                var menuBody = JsonApi.Deserialize<ResponseModel<MenuModel>>(menuJson);
                LocaleApi.AddMenu(langId, menuBody.Data);
            }
        }
    }
}