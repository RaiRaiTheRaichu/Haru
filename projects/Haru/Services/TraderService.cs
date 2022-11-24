using Haru.Models.EFT.Trader;
using Haru.Repositories;

namespace Haru.Services
{
    public class TraderService
    {
        private readonly TraderRepository _traderRepository;

        public TraderService()
        {
            _traderRepository = new TraderRepository();
        }

        public TraderModel[] GetTraders()
        {
            return _traderRepository.GetTraders();
        }
    }
}