using System.Collections.Generic;
using Haru.Models.EFT.Handbook;
using Haru.Models.EFT.Hideout;
using Haru.Models.EFT.Locale;
using Haru.Models.EFT.Location;
using Haru.Models.EFT.Settings;

namespace Haru.Databases
{
    public class Database
    {
        public readonly Dictionary<string, string> Names;
        public readonly Dictionary<string, GlobalModel> Globals;
        public readonly Dictionary<string, MenuModel> Menus;
        public SettingsModel HideoutSettings;
        public readonly List<ScavcaseModel> Scavcases;
        public ClientModel ClientSettings;
        public readonly List<Models.EFT.Trader.TraderModel> Traders;
        public TemplatesModel HandbookTemplates;
        public readonly Dictionary<string, string> Files;
        public WorldMapModel WorldMap;

        private static Database _instance;
        public static Database Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Database();
                }

                return _instance;
            }
        }

        public Database()
        {
            Names = new Dictionary<string, string>();
            Globals = new Dictionary<string, GlobalModel>();
            Menus = new Dictionary<string, MenuModel>();
            Scavcases = new List<ScavcaseModel>();
            Traders = new List<Models.EFT.Trader.TraderModel>();
            Files = new Dictionary<string, string>();
        }
    }
}