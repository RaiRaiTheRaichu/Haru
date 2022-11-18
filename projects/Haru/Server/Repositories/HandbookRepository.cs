using Haru.Models.EFT.Handbook;
using Haru.Server.Databases;

namespace Haru.Server.Repositories
{
    public static class HandbookRepository
    {
        public static TemplatesModel GetTemplates()
        {
            return Database.HandbookTemplates;
        }
    }
}