using Haru.Models.EFT.Handbook;
using Haru.Server.Repositories;

namespace Haru.Server.Services
{
    public static class HandbookService
    {
        public static TemplatesModel GetTemplates()
        {
            return HandbookRepository.GetTemplates();
        }
    }
}