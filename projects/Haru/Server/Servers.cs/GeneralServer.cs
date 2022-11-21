using Haru.Server.Controllers;
using Haru.Server.Http;

namespace Haru.Server
{
    public class GeneralServer
    {
        public HttpServer Server;

        public GeneralServer()
        {
            Server = new HttpServer();

            var router = Server.Router;

            router.AddController<CustomizationStorageController>();
            router.AddController<FriendRequestListInboxController>();
            router.AddController<FriendRequestListOutboxController>();
            router.AddController<GameConfigController>();
            router.AddController<GameLogoutController>();
            router.AddController<GameProfileSelectController>();
            router.AddController<GameStartController>();
            router.AddController<GameVersionValidateController>();
            router.AddController<HandbookBuildsMyListController>();
            router.AddController<HandbookTemplatesController>();
            router.AddController<HideoutProductionScavcaseRecipesController>();
            router.AddController<HideoutSettingsController>();
            router.AddController<LanguagesController>();
            router.AddController<LocaleController>();
            router.AddController<MenuController>();
            router.AddController<NotifierChannelCreateController>();
            router.AddController<ProfileStatusController>();
            router.AddController<ResourceController>();
            router.AddController<ServerListController>();
            router.AddController<SettingsController>();
            router.AddController<TraderSettingsController>();
            router.AddController<WeatherController>();
        }

        public void Start()
        {
            Server.Start();
        }
    }
}