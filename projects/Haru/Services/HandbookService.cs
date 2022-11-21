using Haru.Models.EFT.Handbook;
using Haru.Repositories;

namespace Haru.Services
{
    public static class HandbookService
    {
        public static TemplatesModel GetTemplates()
        {
            return HandbookRepository.GetTemplates();
        }
    }
}