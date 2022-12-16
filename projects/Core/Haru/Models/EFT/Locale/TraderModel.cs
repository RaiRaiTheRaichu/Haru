using Newtonsoft.Json;

namespace Haru.Models.EFT.Locale
{
    public struct TraderModel
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