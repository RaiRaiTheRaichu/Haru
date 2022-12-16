using System.Collections.Generic;
using Haru.Databases;
using Haru.ModApi;
using Haru.Models.EFT;
using Haru.Models.EFT.Handbook;
using Haru.Models.EFT.Hideout;
using Haru.Models.EFT.Locale;
using Haru.Models.EFT.Location;
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
        LoadWorldMap();
        LoadFiles();
    }

    private async static void LoadLanguages()
    {
        var json = await ResourceApi.GetText("Database.Locales.languages.json");
        var names = JsonApi.Deserialize<Dictionary<string, string>>(json);

        foreach (var kvp in names)
        {
            _database.Names.Add(kvp.Key, kvp.Value);
        }
    }

    private async static void LoadGlobals()
    {
        foreach (var kvp in _database.Names)
        {
            var lang = kvp.Key;
            var json = await ResourceApi.GetText($"Database.Locales.all-{lang}.json");
            var body = JsonApi.Deserialize<ResponseModel<GlobalModel>>(json);
            _database.Globals.Add(lang, body.Data);
        }
    }

    private async static void LoadMenus()
    {
        foreach (var kvp in _database.Names)
        {
            var lang = kvp.Key;
            var json = await ResourceApi.GetText($"Database.Locales.menu-{lang}.json");
            var body = JsonApi.Deserialize<ResponseModel<MenuModel>>(json);
            _database.Menus.Add(lang, body.Data);
        }
    }

    private async static void LoadHideoutSettings()
    {
        var json = await ResourceApi.GetText("Database.Settings.hideout.json");
        var body = JsonApi.Deserialize<ResponseModel<SettingsModel>>(json);
        _database.HideoutSettings = body.Data;
    }

    private async static void LoadScavcases()
    {
        var json = await ResourceApi.GetText("Database.Templates.scavcases.json");
        var body = JsonApi.Deserialize<ResponseModel<ScavcaseModel[]>>(json);
        _database.Scavcases.AddRange(body.Data);
    }

    private async static void LoadClientSettings()
    {
        var json = await ResourceApi.GetText("Database.Settings.client.json");
        var body = JsonApi.Deserialize<ResponseModel<ClientModel>>(json);
        _database.ClientSettings = body.Data;
    }

    private async static void LoadTraders()
    {
        var json = await ResourceApi.GetText("Database.Templates.traders.json");
        var body = JsonApi.Deserialize<ResponseModel<Haru.Models.EFT.Trader.TraderModel[]>>(json);
        _database.Traders.AddRange(body.Data);
    }

    private async static void LoadHandbookTemplates()
    {
        var json = await ResourceApi.GetText("Database.Templates.handbook.json");
        var body = JsonApi.Deserialize<ResponseModel<TemplatesModel>>(json);
        _database.HandbookTemplates = body.Data;
    }

    private async static void LoadWorldMap()
    {
        var json = await ResourceApi.GetText("Database.Templates.locations.json");
        var body = JsonApi.Deserialize<ResponseModel<WorldMapModel>>(json);
        _database.WorldMap = body.Data;
    }

    private async static void LoadFiles()
    {
        var json = await ResourceApi.GetText("Database.resxdb.json");
        var files = JsonApi.Deserialize<Dictionary<string, string>>(json);

        foreach (var kvp in files)
        {
            _database.Files.Add(kvp.Key, kvp.Value);
        }
    }
}
