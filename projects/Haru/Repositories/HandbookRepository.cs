using Haru.Databases;
using Haru.Models.EFT.Handbook;

namespace Haru.Repositories
{
    public class HandbookRepository
    {
        private readonly Database _database;

        public HandbookRepository()
        {
            _database = Database.Instance;
        }

        public TemplatesModel GetTemplates()
        {
            return _database.HandbookTemplates;
        }
    }
}