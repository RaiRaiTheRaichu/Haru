using Haru.Models.EFT.Settings;
using Haru.Repositories;

namespace Haru.Services
{
    public class SettingsService
    {
        private readonly SettingsRepository _settingsRepository;

        public SettingsService()
        {
            _settingsRepository = new SettingsRepository();
        }

        public ClientModel GetClientSettings()
        {
            return _settingsRepository.GetClientSettings();
        }
    }
}