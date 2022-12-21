using Haru.Controllers;
using Haru.Http;

namespace Haru.Servers
{
    public class GeneralServer
    {
        public HttpServer Server;

        private static GeneralServer _instance;
        public static GeneralServer Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new GeneralServer();
                }

                return _instance;
            }
        }

        public GeneralServer()
        {
            Server = new HttpServer();

            var router = Server.Router;

            router.AddController<CheckVersionController>();
            router.AddController<CustomizationStorageController>();
            router.AddController<FriendListController>();
            router.AddController<FriendRequestListInboxController>();
            router.AddController<FriendRequestListOutboxController>();
            router.AddController<GameConfigController>();
            router.AddController<GameLogoutController>();
            router.AddController<GameProfileSelectController>();
            router.AddController<GameStartController>();
            router.AddController<GameVersionValidateController>();
            router.AddController<GetLocalLootController>();
            router.AddController<HandbookBuildsMyListController>();
            router.AddController<HandbookTemplatesController>();
            router.AddController<HideoutProductionScavcaseRecipesController>();
            router.AddController<HideoutSettingsController>();
            router.AddController<LanguagesController>();
            router.AddController<LocaleController>();
            router.AddController<LocationController>();
            router.AddController<MailDialogListController>();
            router.AddController<MatchOfflineStartController>();
            router.AddController<MatchOfflineEndController>();
            router.AddController<MenuLocaleController>();
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