using Haru.Models.EFT.Settings;
using Haru.Repositories;

namespace Haru.Services
{
    public static class SettingsService
    {
        public static ClientModel GetClientSettings()
        {
            return SettingsRepository.GetClientSettings();
        }
    }
}