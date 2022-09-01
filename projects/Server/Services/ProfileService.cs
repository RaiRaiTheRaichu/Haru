using Haru.Server.Http;
using Haru.Models.EFT;
using Haru.Server.Services;

namespace Haru.Server.Services
{
    public static class ProfileService
    {
        public CustomizationStorageModel GetCustomizationStorageModel()
        {
            return new CustomizationStorageModel
            {
                ProfileId = "5e23714d4a886443e031fe47",
                Suits = new string[]
                {
                    "5cde9e957d6c8b0474535da7",
                    "5cde9ec17d6c8b04723cf479"
                }
            };
        }

        public ProfileStatusModel[] GetProfileStatusModel()
        {
            var host = HttpServerConfig.GetHost();
            var port = HttpServerConfig.GetPort();

            return new ProfileStatusModel[]
            {
                new ProfileStatusModel("5e23714d4a886443e031fe47", host, port),
                new ProfileStatusModel("5e23714d4a886443e031fe46", host, port)
            };
        }
    }
}