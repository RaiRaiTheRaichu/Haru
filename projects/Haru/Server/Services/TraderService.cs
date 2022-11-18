using Haru.Models.EFT.Trader;
using Haru.Server.Repositories;

namespace Haru.Server.Services
{
    public static class TraderService
    {
        public static TraderModel[] GetTraders()
        {
            return TraderRepository.GetTraders();
        }
    }
}