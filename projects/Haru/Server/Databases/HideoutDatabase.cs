using System.Collections.Generic;
using Haru.Models.EFT;
using Haru.Models.EFT.Hideout;
using Haru.Utils;

namespace Haru.Server.Databases
{
    public static class HideoutDatabase
    {
        public static SettingsModel Settings;
        public static readonly List<ScavcaseModel> Scavcases;

        static HideoutDatabase()
        {
            Scavcases = new List<ScavcaseModel>();

            LoadSettings();
            LoadScavcases();
        }

        private static void LoadSettings()
        {
            var json = Resource.GetText("db.hideout.settings.json");
            var body = Json.Deserialize<ResponseModel<SettingsModel>>(json);
            Settings = body.Data;
        }

        private static void LoadScavcases()
        {
            var json = Resource.GetText("db.hideout.scavcases.json");
            var body = Json.Deserialize<ResponseModel<ScavcaseModel[]>>(json);
            Scavcases.AddRange(body.Data);
        }
    }
}