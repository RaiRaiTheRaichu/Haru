using System.Collections.Generic;
using Haru.Models.EFT;
using Haru.Server.Http;
using Haru.Server.Repositories;

namespace Haru.Server.Services
{
    public static class GameService
    {
        public static GameConfigModel GetGameConfigModel()
        {
            var url = HttpConfig.GetUrl();

            return new GameConfigModel()
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

        public static GameProfileSelectModel SelectProfile(string sessionId)
        {
            var url = HttpConfig.GetUrl();

            return new GameProfileSelectModel()
            {
                Status = "ok",
                NotifierServerModel = new NotifierServerModel(sessionId, url)
            };
        }

        public static GameStartModel StartGame()
        {
            return new GameStartModel()
            {
                LoginTime = 1650550833
            };
        }
    }
}