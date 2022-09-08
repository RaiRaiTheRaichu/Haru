using Haru.Models.EFT.Settings;
using Haru.Server.Repositories;

namespace Haru.Server.Services
{
    public static class SettingsService
    {
        public static ClientModel GetClientSettings()
        {
            return SettingsRepository.GetClientSettings();
        }
    }
}