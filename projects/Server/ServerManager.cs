using Haru.Server.Controllers;
using Haru.Server.Http;

public static class ServerManager
{
    public static readonly HttpServer Server;

    static ServerManager()
    {
        var router = new Router();
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
            new NotifierChannelCreateController(),
            new ProfileStatusController(),
            new ResourceController(),
            new ServerListController()
        };

        foreach (var controller in controllers)
        {
            router.Controllers.Add(controller);
        }

        Server = new HttpServer(router);
    }
}