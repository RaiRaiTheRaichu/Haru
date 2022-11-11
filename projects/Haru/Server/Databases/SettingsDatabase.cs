using Haru.Models.EFT;
using Haru.Models.EFT.Settings;
using Haru.Utils;

namespace Haru.Server.Databases
{
    public static class SettingsDatabase
    {
        public static readonly ClientModel Client;

        static SettingsDatabase()
        {
            var json = Resource.GetText("db.settings.client.json");
            var body = Json.Deserialize<ResponseModel<ClientModel>>(json);
            Client = body.Data;
        }
    }
}