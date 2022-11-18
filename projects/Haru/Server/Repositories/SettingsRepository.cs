using Haru.Models.EFT.Settings;
using Haru.Server.Databases;

namespace Haru.Server.Repositories
{
    public static class SettingsRepository
    {
        public static ClientModel GetClientSettings()
        {
            return Database.ClientSettings;
        }
    }
}