using Newtonsoft.Json;

namespace Haru.Models.EFT
{
    public struct TraderLocaleModel
    {
        [JsonProperty("FullName")]
        public string FullName;

        [JsonProperty("FirstName")]
        public string FirstName;

        [JsonProperty("Nickname")]
        public string Nickname;

        [JsonProperty("Location")]
        public string Location;

        [JsonProperty("Description")]
        public string Description;
    }
}