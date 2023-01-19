using System.Collections.Generic;
using Haru.Controllers;
using Haru.Http;

namespace Haru.Servers
{
    public class GeneralServer
    {
        public readonly Server Server;

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

            var localeController = new LocaleController();
            var menuLocaleController = new MenuLocaleController();
            var resourceController = new ResourceController();

            Server.Controllers = new Dictionary<string, Controller>()
            {
                { "/client/checkVersion",                           new CheckVersionController() },
                { "/client/customization",                          resourceController },
                { "/client/friend/list",                            new FriendListController() },
                { "/client/friend/request/list/inbox",              new FriendRequestListInboxController() },
                { "/client/friend/request/list/outbox",             new FriendRequestListOutboxController() },
                { "/client/game/bot/generate",                      new GameBotGenerateController() },
                { "/client/game/config",                            new GameConfigController() },
                { "/client/game/logout",                            new GameLogoutController() },
                { "/client/game/profile/list",                      resourceController },
                { "/client/game/profile/select",                    new GameProfileSelectController() },
                { "/client/game/start",                             new GameStartController() },
                { "/client/game/version/validate",                  new GameVersionValidateController() },
                { "/client/globals",                                resourceController },
                { "/client/handbook/builds/my/list",                new HandbookBuildsMyListController() },
                { "/client/handbook/templates",                     new HandbookTemplatesController() },
                { "/client/hideout/areas",                          resourceController },
                { "/client/hideout/production/recipes",             resourceController },
                { "/client/hideout/production/scavcase/recipes",    new HideoutProductionScavcaseRecipesController() },
                { "/client/hideout/qte/list",                       resourceController },
                { "/client/hideout/settings",                       new HideoutSettingsController() },
                { "/client/items",                                  resourceController },
                { "/client/languages",                              new LanguagesController() },
                { "/client/locale/ch",                              localeController },
                { "/client/locale/cz",                              localeController },
                { "/client/locale/en",                              localeController },
                { "/client/locale/es",                              localeController },
                { "/client/locale/es-mx",                           localeController },
                { "/client/locale/fr",                              localeController },
                { "/client/locale/ge",                              localeController },
                { "/client/locale/hu",                              localeController },
                { "/client/locale/it",                              localeController },
                { "/client/locale/jp",                              localeController },
                { "/client/locale/kr",                              localeController },
                { "/client/locale/pl",                              localeController },
                { "/client/locale/po",                              localeController },
                { "/client/locale/ru",                              localeController },
                { "/client/locale/sk",                              localeController },
                { "/client/locale/tu",                              localeController },
                { "/client/locations",                              new LocationController() },
                { "/client/location/getLocalloot",                  new LocationGetLootController() },
                { "/client/mail/dialog/list",                       new MailDialogListController() },
                { "/client/match/offline/end",                      new MatchOfflineStartController() },
                { "/client/match/offline/start",                    new MatchOfflineEndController() },
                { "/client/menu/locale/ch",                         menuLocaleController },
                { "/client/menu/locale/cz",                         menuLocaleController },
                { "/client/menu/locale/en",                         menuLocaleController },
                { "/client/menu/locale/es",                         menuLocaleController },
                { "/client/menu/locale/es-mx",                      menuLocaleController },
                { "/client/menu/locale/fr",                         menuLocaleController },
                { "/client/menu/locale/ge",                         menuLocaleController },
                { "/client/menu/locale/hu",                         menuLocaleController },
                { "/client/menu/locale/it",                         menuLocaleController },
                { "/client/menu/locale/jp",                         menuLocaleController },
                { "/client/menu/locale/kr",                         menuLocaleController },
                { "/client/menu/locale/pl",                         menuLocaleController },
                { "/client/menu/locale/po",                         menuLocaleController },
                { "/client/menu/locale/ru",                         menuLocaleController },
                { "/client/menu/locale/sk",                         menuLocaleController },
                { "/client/menu/locale/tu",                         menuLocaleController },
                { "/client/notifier/channel/create",                new NotifierChannelCreateController() },
                { "/client/profile/status",                         new ProfileStatusController() },
                { "/client/quest/list",                             resourceController },
                { "/client/repeatalbeQuests/activityPeriods",       resourceController },
                { "/client/raid/configuration",                     new RaidConfigurationController() },
                { "/client/server/list",                            new ServerListController() },
                { "/client/settings",                               new SettingsController() },
                { "/client/trading/customization/storage",          new CustomizationStorageController() },
                { "/client/trading/api/traderSettings",             new TraderSettingsController() },
                { "/client/weather",                                new WeatherController() }
            };
        }

        public void Start()
        {
            Server.Start();
        }
    }
}