using Haru.Server.Controllers;
using Haru.Server.Http;

public static class ServerManager
{
    public static readonly HttpServer Server;

    static ServerManager()
    {
        var controllers = new Controller[]
        {
            new CustomizationStorageController(),
            new GameConfigController(),
            new GameProfileSelectController(),
            new GameStartController(),
            new GameVersionValidateController(),
            new LanguagesController(),
            new LocaleController(),
            new MenuLocaleController(),
            new NotifierController(),
            new ProfileStatusController(),
            new ResourceController(),
            new ServerListController()
        };

        Server = new HttpServer(controllers);
    }
}