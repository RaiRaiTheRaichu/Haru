using Haru.Helpers;
using Haru.Models.EFT;
using Haru.Models.EFT.Profile;
using Haru.Servers;

namespace Haru.Services
{
    public class ProfileService
    {
        public CustomizationStorageModel GetCustomizationStorageModel()
        {
            // note: dumped EFT server data
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

        public StatusModel GetProfileStatusModel()
        {
            var url = GeneralServer.Instance.Server.Address;
            var host = HttpHelper.GetHost(url);
            var port = HttpHelper.GetPort(url);

            // note: dumped EFT server data
            var profiles = new StatusProfileModel[]
            {
                new StatusProfileModel("5e23714d4a886443e031fe47", host, port),
                new StatusProfileModel("5e23714d4a886443e031fe46", host, port)
            };

            return new StatusModel(profiles);
        }
    }
}