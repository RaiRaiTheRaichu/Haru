using System.Collections.Generic;
using Haru.Models.EFT;
using Haru.Models.EFT.Game;
using Haru.Server.Http;
using Haru.Server.Repositories;

namespace Haru.Server.Services
{
    public static class GameService
    {
        public static ConfigModel GetConfigModel()
        {
            var url = HttpConfig.GetUrl();

            // note: dumped EFT server data
            return new ConfigModel()
            {
                AccountId = 1516319,
                Language = "en",
                Languages = LocaleRepository.GetNames(),
                IsNdaFree = false,
                Taxamony = 6,
                ProfileId = "5e23714d4a886443e031fe47",
                Backends = new Dictionary<string, string>()
                {
                    { "Trading",   url },
                    { "Messaging", url },
                    { "Main",      url },
                    { "RagFair",   url }
                },
                LoginTime = 1650550833,
                TotalPlayersOnline = 1,
                CanReportPlayers = true,
                IsTwitchEventMember = false
            };
        }

        public static ProfileSelectModel SelectProfile(string sessionId)
        {
            var url = HttpConfig.GetUrl();

            // note: dumped EFT server data
            return new ProfileSelectModel()
            {
                Status = "ok",
                NotifierServerModel = new NotifierServerModel(sessionId, url)
            };
        }

        public static StartModel StartGame()
        {
            // note: dumped EFT server data
            return new StartModel()
            {
                LoginTime = 1650550833
            };
        }
    }
}