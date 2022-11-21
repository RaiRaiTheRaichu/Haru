using Haru.Models.EFT.Trader;
using Haru.Repositories;

namespace Haru.Services
{
    public static class TraderService
    {
        public static TraderModel[] GetTraders()
        {
            return TraderRepository.GetTraders();
        }
    }
}