using Haru.Controllers;
using Haru.Http;

namespace Haru.Servers
{
    public class GeneralServer
    {
        public Server Server;

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
            Server = new Server("https://127.0.0.1:8000/");

            var controllers = Server.Router.Controllers;

            controllers.Add(new CheckVersionController());
            controllers.Add(new CustomizationStorageController());
            controllers.Add(new FriendListController());
            controllers.Add(new FriendRequestListInboxController());
            controllers.Add(new FriendRequestListOutboxController());
            controllers.Add(new GameConfigController());
            controllers.Add(new GameLogoutController());
            controllers.Add(new GameProfileSelectController());
            controllers.Add(new GameStartController());
            controllers.Add(new GameVersionValidateController());
            controllers.Add(new GetLocalLootController());
            controllers.Add(new HandbookBuildsMyListController());
            controllers.Add(new HandbookTemplatesController());
            controllers.Add(new HideoutProductionScavcaseRecipesController());
            controllers.Add(new HideoutSettingsController());
            controllers.Add(new LanguagesController());
            controllers.Add(new LocaleController());
            controllers.Add(new LocationController());
            controllers.Add(new MailDialogListController());
            controllers.Add(new MatchOfflineStartController());
            controllers.Add(new MatchOfflineEndController());
            controllers.Add(new MenuLocaleController());
            controllers.Add(new NotifierChannelCreateController());
            controllers.Add(new ProfileStatusController());
            controllers.Add(new RaidConfigurationController());
            controllers.Add(new ResourceController());
            controllers.Add(new ServerListController());
            controllers.Add(new SettingsController());
            controllers.Add(new TraderSettingsController());
            controllers.Add(new WeatherController());
        }

        public void Start()
        {
            Server.Start();
        }
    }
}