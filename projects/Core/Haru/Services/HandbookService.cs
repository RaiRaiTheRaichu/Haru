using Haru.Models.EFT.Handbook;
using Haru.Repositories;

namespace Haru.Services
{
    public class HandbookService
    {
        private readonly HandbookRepository _handbookRepository;

        public HandbookService()
        {
            _handbookRepository = new HandbookRepository();
        }

        public TemplatesModel GetTemplates()
        {
            return _handbookRepository.GetTemplates();
        }
    }
}