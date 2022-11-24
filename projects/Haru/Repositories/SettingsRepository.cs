using Haru.Models.EFT.Settings;
using Haru.Databases;

namespace Haru.Repositories
{
    public class SettingsRepository
    {
        private readonly Database _database;

        public SettingsRepository()
        {
            _database = Database.Instance;
        }

        public ClientModel GetClientSettings()
        {
            return _database.ClientSettings;
        }
    }
}