using Haru.Models.EFT;
using Haru.Models.EFT.Profile;
using Haru.Server.Http;

namespace Haru.Server.Services
{
    public static class ProfileService
    {
        public static CustomizationStorageModel GetCustomizationStorageModel()
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

        public static StatusModel GetProfileStatusModel()
        {
            var host = HttpConfig.GetHost();
            var port = HttpConfig.GetPort();
            var profiles = new StatusProfileModel[]
            {
                new StatusProfileModel("5e23714d4a886443e031fe47", host, port),
                new StatusProfileModel("5e23714d4a886443e031fe46", host, port)
            };

            return new StatusModel(profiles);
        }
    }
}