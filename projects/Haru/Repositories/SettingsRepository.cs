using Haru.Models.EFT.Settings;
using Haru.Databases;

namespace Haru.Repositories
{
    public static class SettingsRepository
    {
        public static ClientModel GetClientSettings()
        {
            return Database.ClientSettings;
        }
    }
}