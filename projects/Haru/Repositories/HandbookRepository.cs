using Haru.Models.EFT.Handbook;
using Haru.Databases;

namespace Haru.Repositories
{
    public static class HandbookRepository
    {
        public static TemplatesModel GetTemplates()
        {
            return Database.HandbookTemplates;
        }
    }
}