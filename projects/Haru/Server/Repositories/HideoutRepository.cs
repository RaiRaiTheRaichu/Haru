using Haru.Models.EFT.Hideout;
using Haru.Server.Databases;

namespace Haru.Server.Repositories
{
    public static class HideoutRepository
    {
        public static SettingsModel GetSettings()
        {
            return HideoutDatabase.Settings;
        }
    }
}