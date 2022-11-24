using System.Collections.Generic;
using Haru.Databases;
using Haru.ModApi;
using Haru.Models.EFT;
using Haru.Models.EFT.Handbook;
using Haru.Models.EFT.Hideout;
using Haru.Models.EFT.Locale;
using Haru.Models.EFT.Settings;

public class Mod
{
    private static readonly Database _database;

    static Mod()
    {
        _database = Database.Instance;
    }

    public static void Run()
    {
        LogApi.Write("Loading Senko.EftData");

        ResourceApi.EnableResourceLoading(typeof(Mod).Assembly);

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
        var json = ResourceApi.GetText("Database.Locales.languages.json");
        var names = JsonApi.Deserialize<Dictionary<string, string>>(json);

        foreach (var kvp in names)
        {
            _database.Names.Add(kvp.Key, kvp.Value);
        }
    }

    private static void LoadGlobals()
    {
        foreach (var kvp in _database.Names)
        {
            var lang = kvp.Key;
            var json = ResourceApi.GetText($"Database.Locales.all-{lang}.json");
            var body = JsonApi.Deserialize<ResponseModel<GlobalModel>>(json);
            _database.Globals.Add(lang, body.Data);
        }
    }

    private static void LoadMenus()
    {
        foreach (var kvp in _database.Names)
        {
            var lang = kvp.Key;
            var json = ResourceApi.GetText($"Database.Locales.menu-{lang}.json");
            var body = JsonApi.Deserialize<ResponseModel<MenuModel>>(json);
            _database.Menus.Add(lang, body.Data);
        }
    }

    private static void LoadHideoutSettings()
    {
        var json = ResourceApi.GetText("Database.Settings.hideout.json");
        var body = JsonApi.Deserialize<ResponseModel<SettingsModel>>(json);
        _database.HideoutSettings = body.Data;
    }

    private static void LoadScavcases()
    {
        var json = ResourceApi.GetText("Database.Templates.scavcases.json");
        var body = JsonApi.Deserialize<ResponseModel<ScavcaseModel[]>>(json);
        _database.Scavcases.AddRange(body.Data);
    }

    private static void LoadClientSettings()
    {
        var json = ResourceApi.GetText("Database.Settings.client.json");
        var body = JsonApi.Deserialize<ResponseModel<ClientModel>>(json);
        _database.ClientSettings = body.Data;
    }

    private static void LoadTraders()
    {
        var json = ResourceApi.GetText("Database.Templates.traders.json");
        var body = JsonApi.Deserialize<ResponseModel<Haru.Models.EFT.Trader.TraderModel[]>>(json);
        _database.Traders.AddRange(body.Data);
    }

    private static void LoadHandbookTemplates()
    {
        var json = ResourceApi.GetText("Database.Templates.handbook.json");
        var body = JsonApi.Deserialize<ResponseModel<TemplatesModel>>(json);
        _database.HandbookTemplates = body.Data;
    }

    private static void LoadFiles()
    {
        var json = ResourceApi.GetText("Database.resxdb.json");
        var files = JsonApi.Deserialize<Dictionary<string, string>>(json);

        foreach (var kvp in files)
        {
            _database.Files.Add(kvp.Key, kvp.Value);
        }
    }
}
