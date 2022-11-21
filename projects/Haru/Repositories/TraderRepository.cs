using Haru.Models.EFT.Trader;
using Haru.Databases;

namespace Haru.Repositories
{
    public static class TraderRepository
    {
        public static TraderModel[] GetTraders()
        {
            return Database.Traders.ToArray();
        }
    }
}