using Newtonsoft.Json;

namespace Haru.Models.EFT.Profile
{
    public struct StatusModel
    {
        [JsonProperty("maxPveCountExceeded")]
        public bool MaxPveCountExceeded;

        [JsonProperty("profiles")]
        public StatusProfileModel[] Profiles;

        public StatusModel(StatusProfileModel[] profiles)
        {
            MaxPveCountExceeded = false;
            Profiles = profiles;
        }
    }
}