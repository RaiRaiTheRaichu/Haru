using Haru.Models.EFT.Hideout;
using Haru.Databases;

namespace Haru.Repositories
{
    public static class HideoutRepository
    {
        public static SettingsModel GetSettings()
        {
            return Database.HideoutSettings;
        }

        public static ScavcaseModel[] GetScavcases()
        {
            return Database.Scavcases.ToArray();
        }
    }
}