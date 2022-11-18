using Haru.Models.EFT;
using Haru.Models.EFT.Hideout;
using Haru.Utils;

namespace Haru.Server.Databases
{
    public static class HideoutDatabase
    {
        public static readonly SettingsModel Settings;

        static HideoutDatabase()
        {
            var json = Resource.GetText("db.hideout.settings.json");
            var body = Json.Deserialize<ResponseModel<SettingsModel>>(json);
            Settings = body.Data;
        }
    }
}