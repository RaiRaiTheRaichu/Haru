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
            var router = Server.Router;

            router.AddController<CustomizationStorageController>();
            router.AddController<GameConfigController>();
            router.AddController<GameProfileSelectController>();
            router.AddController<GameStartController>();
            router.AddController<GameVersionValidateController>();
            router.AddController<LanguagesController>();
            router.AddController<LocaleController>();
            router.AddController<MenuLocaleController>();
            router.AddController<NotifierChannelCreateController>();
            router.AddController<ProfileStatusController>();
            router.AddController<ResourceController>();
            router.AddController<ServerListController>();
        }
    }
}