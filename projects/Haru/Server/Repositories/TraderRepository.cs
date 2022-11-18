using Haru.Models.EFT.Trader;
using Haru.Server.Databases;

namespace Haru.Server.Repositories
{
    public static class TraderRepository
    {
        public static TraderModel[] GetTraders()
        {
            return Database.Traders.ToArray();
        }
    }
}