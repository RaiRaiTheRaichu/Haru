using Haru.Models.EFT.Hideout;
using Haru.Repositories;

namespace Haru.Services
{
    public static class HideoutService
    {
        public static SettingsModel GetSettings()
        {
            return HideoutRepository.GetSettings();
        }

        public static ScavcaseModel[] GetScavcases()
        {
            return HideoutRepository.GetScavcases();
        }
    }
}