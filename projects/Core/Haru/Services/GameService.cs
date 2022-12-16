using System.Collections.Generic;
using Haru.Models.EFT.Game;
using Haru.Http;
using Haru.Repositories;

namespace Haru.Services
{
    public class GameService
    {
        private readonly LocaleRepository _localeRepository;

        public GameService()
        {
            _localeRepository = new LocaleRepository();
        }

        public ConfigModel GetConfigModel()
        {
            var url = HttpConfig.GetUrl();

            // note: dumped EFT server data
            return new ConfigModel()
            {
                AccountId = 1516319,
                Language = "en",
                Languages = _localeRepository.GetNames(),
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

        public StartModel StartGame()
        {
            // note: dumped EFT server data
            return new StartModel()
            {
                LoginTime = 1650550833
            };
        }

        public CheckVersionModel IsCorrectVersion()
        {
            // note: dumped EFT server data
            return new CheckVersionModel()
            {
                IsValid = true,
                LatestVersion = "0.12.12.32.20243"
            };
        }
    }
}