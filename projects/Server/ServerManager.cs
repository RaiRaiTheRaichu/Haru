using Haru.Server.Controllers;
using Haru.Server.Http;

namespace Haru.Server
{
    public static class ServerManager
    {
        public static readonly HttpServer Server;

        static ServerManager()
        {
            Server = new HttpServer();
        }

        public static void Initialize()
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
                new NotifierChannelCreateController(),
                new ProfileStatusController(),
                new ResourceController(),
                new ServerListController()
            };

            foreach (var controller in controllers)
            {
                Server.Router.Controllers.Add(controller);
            }
        }
    }
}